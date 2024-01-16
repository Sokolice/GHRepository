namespace api.DTOs
{
    public class PestDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Advice { get; set; }
        public string ImageSrc { get; set; }  

        public PestDTO()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            Advice = string.Empty;
            ImageSrc = string.Empty;
        }
    }
}
