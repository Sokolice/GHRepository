using API.Domain;

namespace API.DTOs
{
    public class StatsDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime WeatherChecked { get; set; }
        public bool FreezeAlert { get; set; }
        public bool HighTemperatureAlert { get; set; }
        public bool RainPeriodAlert { get; set; }
        public int MissingSowingThisWeekAmount { get; set; }
        public int MissingTaskThisWeekAmount { get; set; }
        public int CanBeSowedRepeatedlyAmount { get; set; }
        public int ReadyToHarvestAmount { get; set; }
        public string CanBeSowedThisWeek { get; set; }
        public string CanBeSowedRepeatedly { get; set; }
        public string ReadyToHarvest { get; set; }

        public StatsDTO()
        {
            CanBeSowedRepeatedly = string.Empty;
            CanBeSowedThisWeek =string.Empty;
            ReadyToHarvest = string.Empty;
        }
    }
}
