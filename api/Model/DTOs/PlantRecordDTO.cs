namespace api.Model.DTOs
{
    public class PlantRecordDTO
    {
        public Guid Id { get; set; }
        public Guid PlantId { get; set; }
        public PlantDTO Plant { get; set; }
        public DateTime DatePlanted { get; set; }
        public int AmountPlanted { get; set; }

        public PlantRecordDTO()
        {
            Id = Guid.NewGuid();
            Plant = new PlantDTO();
            PlantId = Guid.NewGuid();
        }
    }
}
