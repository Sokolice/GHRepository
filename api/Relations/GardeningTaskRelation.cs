using API.DTOs;

namespace API.Relations
{
    public class GardeningTaskRelation
    {
        public GardeningTaskDTO GardeningTask { get; set; }
        public List<MonthWeekDTO> MonthhWeeks { get; set; }

        public GardeningTaskRelation()
        {
            GardeningTask = new GardeningTaskDTO();
            MonthhWeeks = new List<MonthWeekDTO>();
        }
    }

}
