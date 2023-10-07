namespace api.Model.DTOs
{
    public class MonthWeekDTO
    {
        public string Month { get; set; }
        public int Week { get; set; }

        public virtual List<Guid> SewedPlant { get; set; }
        public virtual List<Guid> HarvestedPlant { get; set; }

        public virtual List<Guid> GardeningTasks { get; set; }

        public MonthWeekDTO()
        {
            Month = string.Empty;
            Week = 0;
            SewedPlant = new List<Guid>();
            HarvestedPlant = new List<Guid>();
            GardeningTasks = new List<Guid>();
        }
    }
}
