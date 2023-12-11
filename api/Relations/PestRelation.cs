using api.DTOs;

namespace api.Relations
{
    public class PestRelation
    {
        public PestDTO PestDTO { get; set; }

        public List<PlantDTO> Plants { get; set; }
    }
}
