using API.Core;
using API.Model;
using API.Persistence;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace API.Services
{
    public class StatsService: IStatsService
    {
        private readonly DataContext _context;
        private readonly Stats stats;

        public StatsService(DataContext context)
        {
            _context = context;
            stats = new Stats();
        }

        public async Task<Result<Stats>> GetStats()
        {
            await ThisWeekSowingCalculation();
            await RepeatedPlanting();
            await CheckWeatherStats();
            await ReadyToHarvestStats();

            _context.Stats.Add(stats);
            var result = await _context.SaveChangesAsync() > 0;

            if (!result)
                return Result<Stats>.Failure("Failed to save stats", false);

            return Result<Stats>.Success(stats);
                
        }

        public async Task ThisWeekSowingCalculation()
        {

            var month = DateTime.Today.Month;
            double day = DateTime.Today.Day;
            var weekOfMonth = Math.Ceiling(day / 7);

            if (weekOfMonth > 4)
                weekOfMonth = 4;

            var plants = await _context.Plants
                .Include(p => p.PlantRecords)
                .Where(a => a.SewingMonths.Any(sm => sm.MonthIndex == month && sm.Week == weekOfMonth)).ToListAsync();

            stats.CanBeSowedThisWeek = string.Join(",", plants
                                .Where(a => a.PlantRecords.Count == 0)
                                .Select(p => p.Id.ToString())
                                .ToArray());

            stats.MissingSowingThisWeekAmount = plants
                                            .Where(a => a.PlantRecords.Count == 0)
                                            .Count();

            stats.MissingTaskThisWeekAmount = _context.Tasks
                                            .Where(a => a.MonthWeeks
                                            .Any(sm => sm.MonthIndex == month && sm.Week == weekOfMonth) && a.IsCompleted == false)
                                            .Count();

        }

        public async Task RepeatedPlanting()
        {
            var today = DateTime.Now;

            var records = await _context.PlantRecords
                            .Where(r => r.Plant.RepeatedPlanting > 0)
                            .ToListAsync();

            foreach (var record in records)
            {
                if ((today - record.DatePlanted).TotalDays >= 14)
                {
                    stats.CanBeSowedRepeatedlyAmount++;
                    stats.CanBeSowedRepeatedly = string.Join(",", stats.CanBeSowedRepeatedly, record.PlantId);
                }
            }

        }

        public async Task CheckWeatherStats()
        {
            var now = DateTime.Now;
            var last = now;
            var lastStatsWeather = new Stats();
            if (_context.Stats != null)
            {
                lastStatsWeather = _context.Stats.OrderByDescending(a => a.WeatherChecked).FirstOrDefault();
                if (lastStatsWeather != null)
                {
                    last = lastStatsWeather.WeatherChecked;
                }

            }

            if ((now - last).Hours > 4 || last == now)
            {
                stats.WeatherChecked = DateTime.Now;
                await GetDataFromWeatherAPI();
            }
            else
            {
                if (lastStatsWeather != null)
                {
                    stats.FreezeAlert = lastStatsWeather.FreezeAlert;
                    stats.HighTemperatureAlert = lastStatsWeather.HighTemperatureAlert;
                    stats.RainPeriodAlert = lastStatsWeather.RainPeriodAlert;
                }
            }

        }

        public async Task GetDataFromWeatherAPI()
        {
            var defLongtitude = 18.262;
            var defLatitude = 49.817;
            string result;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.openweathermap.org");
                var response = await client.GetAsync("data/3.0/onecall?lat=" + defLatitude + "&lon=" + defLongtitude + "&exclude=minutely,hourly,current&units=metric&appid=" + Variables.OPEN_WEATHER_API_KEY);

                result = response.Content.ReadAsStringAsync().Result;
            }

            JObject apiResponse = JObject.Parse(result);

            if (!apiResponse.TryGetValue("daily", out var daily))
            {
                throw new Exception("missing data in response from OpenWeather API");
            }

            IList<JToken> apiResults = daily.Children().ToList();

            List<DailyObj> weatherObjects = new List<DailyObj>();
            foreach (JToken r in apiResults)
            {
                DailyObj searchResult = r.ToObject<DailyObj>();
                weatherObjects.Add(searchResult);
            }

            stats.FreezeAlert = weatherObjects.Any(a => a.Temp.Min <= 0);
            stats.HighTemperatureAlert = weatherObjects.Any(a => a.Temp.Max >= 28);
            stats.RainPeriodAlert = weatherObjects.Where(a => a.Weather.Any(b => b.Id.StartsWith("5"))).Count() >= 6;
        }

        public async Task ReadyToHarvestStats()
        {
            var records = await _context.PlantRecords.ToListAsync();

            var recordsDTO = MyMapping.MapPlantRecordsList(records);

            foreach (var recordDTO in recordsDTO)
            {
                if (recordDTO.Progress >= 100)
                {
                    stats.ReadyToHarvest = string.Join(",", stats.ReadyToHarvest, recordDTO.PlantId);
                    stats.ReadyToHarvestAmount++;
                }
            }
        }

    }
}
