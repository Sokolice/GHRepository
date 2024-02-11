namespace api.DTOs
{
    public class PlantRecordDTO
    {
        public Guid Id { get; set; }
        public Guid PlantId { get; set; }
        public DateTime DatePlanted { get; set; }
        public int AmountPlanted { get; set; }
        public DateTime PresumedHarvest { get; set; }


        public PlantRecordDTO()
        {
            Id = Guid.NewGuid();
            PlantId = Guid.NewGuid();
        }
    }
}
