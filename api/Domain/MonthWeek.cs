using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace API.Domain
{
    [PrimaryKey(nameof(Month), nameof(Week))]
    public class MonthWeek
    {
        public string Month { get; set; }
        public int MonthIndex {  get; set; }
        public int Week { get; set; }

        public virtual List<Plant> SewedPlants { get; set; }
        public virtual List<Plant> HarvestedPlants { get; set; }

        public virtual List<PlantType> SewedPlantTypes { get; set; }
        public virtual List<PlantType> HarvestedPlantTypes { get; set; }

        public virtual List<GardeningTask> GardeningTasks { get; set; }

        public MonthWeek() {
            Month = string.Empty;
            Week = 0;
            SewedPlants = new List<Plant>();
            HarvestedPlants = new List<Plant>();
            GardeningTasks = new List<GardeningTask>();
            SewedPlantTypes = new List<PlantType>();
            HarvestedPlantTypes = new List<PlantType>();
        }
    }
}
