using System.Drawing;

namespace api.Model
{
    public class MonthWeek
    {
        public string Month { get; set; }
        public int Week { get; set; }

        public MonthWeek() {
            Week = 1;
        }
    }
}
