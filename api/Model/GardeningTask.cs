namespace API.Model
{
    public class GardeningTask
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<MonthWeek> MonthWeeks { get; set; }

        public bool IsCompleted { get; set; }

        public bool WasSent { get; set; }

        public GardeningTask()
        {
            Id = Guid.NewGuid();
            MonthWeeks = new List<MonthWeek>();
            Name = string.Empty;
            IsCompleted = false;
            WasSent = false;
        }
    }
}
