namespace api.Model
{
    public class Plant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        //mozna muze byt nekonacna smycka v odkazovani na listy, podivat se jak resit lazy loading 
        

        public bool IsHybrid { get; set; }

        public bool DirectSewing { get; set; }

        public int GerminationTemp { get; set; }
        public List<MonthWeek> SewingMonths { get; set; }
        public List<MonthWeek> HarvestMonths { get; set; }

        public List<Plant> CompanionPlants { get; set; }

        public List<Plant> AvoidPlants { get; set; }

        //trat ve ktere se pestuje 
        public int CropRotation { get; set; }

        public string Description { get; set; }

        public string ImageSrc {  get; set; }

        public int RepeatedPlanting { get; set; }

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
        }

    }


}
