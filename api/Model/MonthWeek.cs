using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace API.Model
{
    [PrimaryKey(nameof(Month), nameof(Week))]
    public class MonthWeek
    {
        public string Month { get; set; }
        public int MonthIndex {  get; set; }
        public int Week { get; set; }

        public virtual List<Plant> SewedPlant { get; set; }
        public virtual List<Plant> HarvestedPlant { get; set; }

        public virtual List<GardeningTask> GardeningTasks { get; set; }

        public MonthWeek() {
            Month = string.Empty;
            Week = 0;
            SewedPlant = new List<Plant>();
            HarvestedPlant = new List<Plant>();
            GardeningTasks = new List<GardeningTask>();
        }
    }
}
