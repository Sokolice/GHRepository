namespace api.Model
{
    public class PlantDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsHybrid { get; set; }

        public bool DirectSewing { get; set; }

        public int GerminationTemp { get; set; }
        public List<Tuple<string, int>> SewingMonths { get; set; }
        public List<Tuple<string, int>> HarvestMonths { get; set; }

        public virtual List<Guid> CompanionPlants { get; set; }

        public virtual List<Guid> AvoidPlants { get; set; }

        //trat ve ktere se pestuje 
        public int CropRotation { get; set; }

        public string Description { get; set; }

        public string ImageSrc { get; set; }

        public int RepeatedPlanting { get; set; }

        public virtual List<PlantRecord> PlantRecords { get; set; }

        public PlantDTO()
        {
            Id = new Guid();
            Name = string.Empty;
            CompanionPlants = new List<Guid>();
            AvoidPlants = new List<Guid>();
            SewingMonths = new List<Tuple<string, int>>();
            HarvestMonths = new List<Tuple<string, int>>();
            Description = string.Empty;
            ImageSrc = string.Empty;
            RepeatedPlanting = 0;
            PlantRecords = new List<PlantRecord>();
        }
    }
}
