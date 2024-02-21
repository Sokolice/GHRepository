using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Plant
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsHybrid { get; set; }

        public bool DirectSewing { get; set; }

        public int GerminationTemp { get; set; }
        public virtual List<MonthWeek> SewingMonths { get; set; }
        public virtual List<MonthWeek> HarvestMonths { get; set; }

        public virtual List<Plant> CompanionPlants { get; set; }

        public virtual List<Plant> AvoidPlants { get; set; }

        public virtual List<Plant> CompanionPlants2 { get; set; }

        public virtual List<Plant> AvoidPlants2 { get; set; }

        //trat ve ktere se pestuje 
        public int CropRotation { get; set; }

        public string Description { get; set; }

        public string ImageSrc {  get; set; }

        public int RepeatedPlanting { get; set; }

        public virtual List<PlantRecord> PlantRecords { get; set; }

        public virtual List<Pest> Pests { get; set; }

        public Plant()
        {
            Id = new Guid();
            Name = string.Empty;
            CompanionPlants = new List<Plant>();
            AvoidPlants = new List<Plant>();
            SewingMonths = new List<MonthWeek>();
            HarvestMonths = new List<MonthWeek>();
            Description = string.Empty;
            ImageSrc = string.Empty;
            RepeatedPlanting = 0;
            PlantRecords = new List<PlantRecord>();
            Pests = new List<Pest>();
        }

    }


}
