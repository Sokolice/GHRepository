using api.Model.DTOs;

namespace api.Model.Relations
{
    public class GardeningTaskRelation
    {
        public GardeningTaskDTO GardeningTask { get; set; }
        public List<MonthWeekDTO> MonthhWeeks { get; set; }
    }
}
