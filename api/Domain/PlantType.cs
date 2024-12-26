using API.Model;
using System.ComponentModel.DataAnnotations;

namespace API.Domain
{
    public class PlantType
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public bool DirectSewing { get; set; }
        public bool PreCultivation { get; set; }

        public int GerminationTemp { get; set; }
        public virtual List<MonthWeek> SewingMonths { get; set; }
        public virtual List<MonthWeek> HarvestMonths { get; set; }

        public virtual List<PlantType> CompanionPlantTypes { get; set; }

        public virtual List<PlantType> AvoidPlantTypes { get; set; }

        public virtual List<PlantType> CompanionPlantTypes2 { get; set; }

        public virtual List<PlantType> AvoidPlantTypes2 { get; set; }

        public int CropRotation { get; set; }

        public string Description { get; set; }

        public string ImageSrc { get; set; }

        public int RepeatedPlanting { get; set; }

        public virtual List<Pest> Pests { get; set; }
        public virtual List<Plant> Plants { get; set; }
        public long MinTemperature { get; set; }
        public int PlantHeight { get; set; }
        public int PlantSpace { get; set; }
        public int RowSpace { get; set; }

        public PlantType()
        {
            AvoidPlantTypes = new List<PlantType>();
            AvoidPlantTypes2 = new List<PlantType>();
            SewingMonths = new List<MonthWeek>();
            HarvestMonths = new List<MonthWeek>();
            CompanionPlantTypes = new List<PlantType>();
            CompanionPlantTypes2 = new List<PlantType>();
            Name = string.Empty;
            Description = string.Empty;
            ImageSrc = string.Empty;
            Pests = new List<Pest>();
            Plants = new List<Plant>();
            MinTemperature = 0;
            PlantHeight = 0;
            RowSpace = 0;
            PlantSpace = 0;
        }
    }
}
