namespace api.DTOs
{
    public class MonthWeekDTO
    {
        public string Month { get; set; }
        public int MonthIndex {  get; set; }
        public int Week { get; set; }


        public MonthWeekDTO()
        {
            Month = string.Empty;
            Week = 0;
        }
    }
}
