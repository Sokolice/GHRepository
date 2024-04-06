using API.Domain;
using System.ComponentModel.DataAnnotations;

namespace API.Domain
{
    public class Pest
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Advice { get; set; }

        public virtual List<PlantType> Plants { get; set; }

        public string ImageSrc { get; set; }

        public Pest()
        {
            Plants = new List<PlantType>();
            Id = Guid.NewGuid();
            Name = string.Empty;
            Advice = string.Empty;
            ImageSrc = string.Empty;
        }
    }
}
