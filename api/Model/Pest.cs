namespace API.Model
{
    public class Pest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Advice { get; set; }

        public virtual List<Plant> Plants { get; set; }

        public string ImageSrc { get; set; }

        public Pest()
        {
            Plants = new List<Plant>();
            Id = Guid.NewGuid();
            Name = string.Empty;
            Advice = string.Empty;
            ImageSrc = string.Empty;
        }
    }
}
