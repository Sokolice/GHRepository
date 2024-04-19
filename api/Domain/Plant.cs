
using System.ComponentModel.DataAnnotations;

namespace API.Domain
{
    public class Plant
    {

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsHybrid { get; set; }

        public bool DirectSewing { get; set; }
        public bool PreCultivation { get; set; }

        public int GerminationTemp { get; set; }
        public virtual List<MonthWeek> SewingMonths { get; set; }
        public virtual List<MonthWeek> HarvestMonths { get; set; }

        public int CropRotation { get; set; }
        public string Description { get; set; }

        public string ImageSrc {  get; set; }

        public int RepeatedPlanting { get; set; }

        public virtual List<PlantRecord> PlantRecords { get; set; }

        
        public virtual PlantType PlantType { get; set; }
        public Guid PlantTypeId { get; set; }

        public virtual List<AppUser> Users { get; set; }

        public bool IsApproved {  get; set; }

        public Plant()
        {
            Id = new Guid();
            Name = string.Empty;
            SewingMonths = new List<MonthWeek>();
            HarvestMonths = new List<MonthWeek>();
            Description = string.Empty;
            ImageSrc = string.Empty;
            RepeatedPlanting = 0;
            PlantRecords = new List<PlantRecord>();
            Users = new List<AppUser>();
        }
    }


}
