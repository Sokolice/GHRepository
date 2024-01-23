namespace api.DTOs
{
    public class GardeningTaskDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public bool IsCompleted { get; set; }

        public bool WasSent { get; set; }
        public GardeningTaskDTO()
        {
            Name = string.Empty;
            IsCompleted = false;
            WasSent = false;
        }
    }
}
