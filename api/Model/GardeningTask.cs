namespace api.Model
{
    public class GardeningTask
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<MonthWeek> MonthWeeks { get; set; }

        public GardeningTask()
        {
            MonthWeeks = new List<MonthWeek>();
            Name = string.Empty;
            Description = string.Empty;
        }
    }
}
