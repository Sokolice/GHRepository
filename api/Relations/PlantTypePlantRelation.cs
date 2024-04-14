using API.Domain;
using API.DTOs;

namespace API.Relations
{
    public class PlantTypePlantsRelation
    {
        public PlantTypeDTO PlantType { get; set; }
        public List<PlantDTO> Plants { get; set; }
    }
}
