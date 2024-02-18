using api.Core;
using api.DTOs;
using api.Persistence;
using api.Relations;
using Humanizer;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing.Drawing2D;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace api.Model
{
    public class Stats
    {
        private readonly DataContext _context;

        public bool FreezeAlert { get; set; }
        public bool HighTemperatureAlert { get; set; }
        public bool RainPeriodAlert { get; set; }
        public int MissingSowingThisWeekAmount { get; set; }
        public int MissingTaskThisWeekAmount { get; set; }
        public int CanBeSowedRepeatedlyAmount { get; set; }
        public int ReadyToHarvestAmount { get; set; }
        public List<Guid> CanBeSowedThisWeek { get; set; }
        public List<Guid> CanBeSowedRepeatedly { get; set; }
        public List<Guid> ReadyToHarvest { get; set; }



        public Stats(DataContext context)
        {
            _context = context;
            CanBeSowedThisWeek = new List<Guid>();
            CanBeSowedRepeatedly = new List<Guid>();
            ReadyToHarvest = new List<Guid>();
            CanBeSowedRepeatedlyAmount = 0;
            ReadyToHarvestAmount = 0;
        }


        public async Task ThisWeekSowingCalculation()
        {

            var month = DateTime.Today.Month;
            double day = DateTime.Today.Day;
            var weekOfMonth = Math.Ceiling(day / 7);

            var plants = _context.Plants
                .Include(p => p.PlantRecords)
                .Where(a => a.SewingMonths.Any(sm => sm.MonthIndex == month && sm.Week == weekOfMonth)).ToList();
            
            CanBeSowedThisWeek = plants
                                .Where(a => a.PlantRecords.Count == 0)
                                .Select(p => p.Id)
                                .ToList();

            MissingSowingThisWeekAmount = plants
                                            .Where(a => a.PlantRecords.Count == 0)
                                            .Count();

            MissingTaskThisWeekAmount = _context.Tasks
                                            .Where(a => a.MonthWeeks
                                            .Any(sm => sm.MonthIndex == month && sm.Week == weekOfMonth) && a.IsCompleted == false)
                                            .Count();

            var today = DateTime.Now;

            var records = _context.PlantRecords
                            .Where(r => r.Plant.RepeatedPlanting > 0)
                            .ToList();

           foreach(var record in records)
            {
                if ((today - record.DatePlanted).TotalDays >= 14)
                    CanBeSowedRepeatedlyAmount++;

                CanBeSowedRepeatedly.Add(record.PlantId);
            }

            await CheckWeatherAsync();
            ReadyToHarvestStats();
        }


        public async Task CheckWeatherAsync()
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

            FreezeAlert = weatherObjects.Any(a => a.Temp.Min <= 0);
            HighTemperatureAlert = weatherObjects.Any(a => a.Temp.Max >= 28);
            RainPeriodAlert =  weatherObjects.Where(a => a.Weather.Any(b => b.Id.StartsWith("5"))).Count() >= 6;
        }

        public void ReadyToHarvestStats()
        {
            var records = _context.PlantRecords.ToList();

            var recordsDTO = MyMapping.MapPlantRecordsList(records);

            foreach(var recordDTO in recordsDTO)
            {
                if(recordDTO.Progress >= 100)
                {
                    ReadyToHarvest.Add(recordDTO.Id);
                    ReadyToHarvestAmount++;
                }
            }
        }
    }
}
