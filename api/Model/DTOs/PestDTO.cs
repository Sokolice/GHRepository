namespace api.Model.DTOs
{
    public class PestDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Advice { get; set; }


        public PestDTO()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            Advice = string.Empty;
        }
    }
}
