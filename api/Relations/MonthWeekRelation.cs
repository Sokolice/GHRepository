using api.DTOs;

namespace api.Relations
{
    public class MonthWeekRelation
    {
        public MonthWeekDTO MonthWeekDTO { get; set; }
        public virtual List<PlantDTO> SewedPlants { get; set; }
        public virtual List<PlantDTO> HarvestedPlants { get; set; }

        public virtual List<GardeningTaskDTO> GardeningTasks { get; set; }

        public MonthWeekRelation()
        {
            MonthWeekDTO = new MonthWeekDTO();
            SewedPlants = new List<PlantDTO>();
            HarvestedPlants = new List<PlantDTO>();
            GardeningTasks = new List<GardeningTaskDTO>();
        }
    }
}
