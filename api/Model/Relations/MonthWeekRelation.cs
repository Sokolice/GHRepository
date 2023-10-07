using api.Model.DTOs;

namespace api.Model.Relations
{
    public class MonthWeekRelation
    {
        public MonthWeekDTO MonthWeekDTO { get; set; }
        public virtual List<PlantDTO> SewedPlant { get; set; }
        public virtual List<PlantDTO> HarvestedPlant { get; set; }

        public virtual List<GardeningTaskDTO> GardeningTasks { get; set; }

    }
}
