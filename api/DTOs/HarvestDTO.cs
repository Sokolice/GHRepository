namespace API.DTOs
{
    public class HarvestDTO
    {
        public Guid Id { get; set; }
        public Guid PlantId { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public int Rating { get; set; }
        public string Note { get; set; }
        public int Unit { get; set; }

        public HarvestDTO()
        {
            Id = Guid.NewGuid();
            PlantId = Guid.NewGuid();
            Date = DateTime.Now;
            Rating = 0;
            Note = string.Empty;
            Amount = 0;
            Unit = 0;
        }
    }
}
