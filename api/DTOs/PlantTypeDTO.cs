using API.Domain;
using API.Core;

namespace API.DTOs
{
    public class PlantTypeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public bool DirectSewing { get; set; }
        public bool PreCultivation { get; set; }

        public int GerminationTemp { get; set; }

        public int CropRotation { get; set; }

        public string Description { get; set; }

        public string ImageSrc { get; set; }

        public int RepeatedPlanting { get; set; }

        public MonthWeekDTO SowingFrom { get; set; }
        public MonthWeekDTO SowingTo { get; set; }
        public MonthWeekDTO HarvestFrom { get; set; }
        public MonthWeekDTO HarvestTo { get; set; }


        public PlantTypeDTO()
        {
            Name = string.Empty;
            Description = string.Empty;
            ImageSrc = string.Empty;
        }

        public PlantTypeDTO(PlantType plantType)
        {
            Id = plantType.Id;
            Name = plantType.Name;
            Description = plantType.Description;
            DirectSewing = plantType.DirectSewing;
            PreCultivation = plantType.PreCultivation;
            GerminationTemp = plantType.GerminationTemp;
            CropRotation = plantType.CropRotation;
            ImageSrc = plantType.ImageSrc;
            RepeatedPlanting = plantType.RepeatedPlanting;
            SowingFrom = MyMapping.MapMonthWeekToDTO(plantType.SewingMonths.OrderBy(a=> a.MonthIndex).ThenBy(a=> a.Week).First());
            SowingTo = MyMapping.MapMonthWeekToDTO(plantType.SewingMonths.OrderBy(a => a.MonthIndex).ThenBy(a => a.Week).Last());
            HarvestFrom = MyMapping.MapMonthWeekToDTO(plantType.HarvestMonths.OrderBy(a => a.MonthIndex).ThenBy(a => a.Week).First());
            HarvestTo = MyMapping.MapMonthWeekToDTO(plantType.HarvestMonths.OrderBy(a => a.MonthIndex).ThenBy(a => a.Week).Last());
        }
    }
}
