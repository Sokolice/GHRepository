using api.DTOs;

namespace api.Relations
{
    public class MonthTaskRelation
    {
        public MonthWeekDTO MonthWeekDTO { get; set; }
        public virtual List<GardeningTaskDTO> GardeningTasks { get; set; }

    }
}
