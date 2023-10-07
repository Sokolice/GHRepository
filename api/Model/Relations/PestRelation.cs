using api.Model.DTOs;

namespace api.Model.Relations
{
    public class PestRelation
    {
        public PestDTO PestDTO { get; set; }

        public List<PlantDTO> Plants { get; set; }
    }
}
