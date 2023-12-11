namespace api.DTOs
{
    public class GardeningTaskDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public GardeningTaskDTO()
        {
            Name = string.Empty;
            Description = string.Empty;
        }
    }
}
