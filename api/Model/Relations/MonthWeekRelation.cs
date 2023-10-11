using api.Model.DTOs;

namespace api.Model.Relations
{
    public class MonthWeekRelation
    {
        public MonthWeekDTO MonthWeekDTO { get; set; }
        public virtual List<PlantDTO> SewedPlants { get; set; }
        public virtual List<PlantDTO> HarvestedPlants { get; set; }

        public virtual List<GardeningTaskDTO> GardeningTasks { get; set; }

    }
}
