using api.DTOs;

namespace api.Relations
{
    public class GardeningTaskRelation
    {
        public GardeningTaskDTO GardeningTask { get; set; }
        public List<MonthWeekDTO> MonthhWeeks { get; set; }
    }
}
