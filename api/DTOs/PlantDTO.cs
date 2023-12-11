namespace api.DTOs
{
    public class PlantDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsHybrid { get; set; }

        public bool DirectSewing { get; set; }

        public int GerminationTemp { get; set; }

        //trat ve ktere se pestuje 
        public int CropRotation { get; set; }

        public string Description { get; set; }

        public string ImageSrc { get; set; }

        public int RepeatedPlanting { get; set; }


        public PlantDTO()
        {
            Id = new Guid();
            Name = string.Empty;
            Description = string.Empty;
            ImageSrc = string.Empty;
            RepeatedPlanting = 0;
        }
    }
}
