using API.DTOs;

namespace API.Relations
{
    public class PlantPlantsRelation
    {
        public PlantDTO Plant { get; set; }
        public List<PlantDTO> CompanionPlants { get; set; }

        public List<PlantDTO> AvoidPlants { get; set; }

        public PlantPlantsRelation()
        {
            Plant = new PlantDTO();
            CompanionPlants = new List<PlantDTO>();
            AvoidPlants = new List<PlantDTO>();
        }
    }
}
