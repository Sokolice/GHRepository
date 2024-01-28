using api.DTOs;

namespace api.Relations
{
    public class MonthTaskRelation
    {
        public MonthWeekDTO MonthWeekDTO { get; set; }
        public virtual List<GardeningTaskDTO> GardeningTasks { get; set; }

        public MonthTaskRelation()
        {
            MonthWeekDTO = new MonthWeekDTO();
            GardeningTasks= new List<GardeningTaskDTO>();
        }

    }
}
