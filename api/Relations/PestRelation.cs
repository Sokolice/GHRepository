using API.DTOs;

namespace API.Relations
{
    public class PestRelation
    {
        public PestDTO PestDTO { get; set; }

        public List<PlantDTO> Plants { get; set; }

        public PestRelation()
        {
            Plants = new List<PlantDTO>();
            PestDTO = new PestDTO();
        }
    }
}
