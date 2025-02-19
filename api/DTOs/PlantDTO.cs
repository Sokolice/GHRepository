﻿using API.Core;
using API.Domain;

namespace API.DTOs
{
    public class PlantDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsHybrid { get; set; }

        public bool DirectSewing { get; set; }
        public bool PreCultivation { get; set; }

        public int GerminationTemp { get; set; }

        //trat ve ktere se pestuje 
        public int CropRotation { get; set; }

        public string Description { get; set; }

        public string ImageSrc { get; set; }

        public int RepeatedPlanting { get; set; }
        public MonthWeekDTO SowingFrom { get; set; }
        public MonthWeekDTO SowingTo { get; set; }
        public MonthWeekDTO HarvestFrom { get; set; }
        public MonthWeekDTO HarvestTo { get; set; }

        public Guid PlantTypeId { get; set; }

        public long MinTemperature { get; set; }
        public int PlantHeight { get; set; }
        public int PlantSpace { get; set; }
        public int RowSpace { get; set; }

        public PlantDTO()
        {
            Id = new Guid();
            Name = string.Empty;
            Description = string.Empty;
            ImageSrc = string.Empty;
            RepeatedPlanting = 0;
        }

        public PlantDTO(Plant aPlant)
        {
            Id = aPlant.Id;
            Name = aPlant.Name;
            IsHybrid = aPlant.IsHybrid;
            DirectSewing = aPlant.DirectSewing;
            GerminationTemp = aPlant.GerminationTemp;
            CropRotation = aPlant.PlantType.CropRotation;
            Description = aPlant.Description;
            ImageSrc = aPlant.ImageSrc;
            RepeatedPlanting = aPlant.RepeatedPlanting;
            PreCultivation = aPlant.PreCultivation;
            PlantTypeId = aPlant.PlantTypeId;
            MinTemperature = aPlant.MinTemperature ?? aPlant.PlantType.MinTemperature;
            PlantHeight = aPlant.PlantHeight ?? aPlant.PlantType.PlantHeight;
            PlantSpace = aPlant.PlantSpace ?? aPlant.PlantType.PlantSpace;
            RowSpace = aPlant.RowSpace ?? aPlant.PlantType.RowSpace;

            if(aPlant.SewingMonths.Count > 0)
            {
                SowingFrom = MyMapping.MapMonthWeekToDTO(aPlant.SewingMonths.OrderBy(a => a.MonthIndex).ThenBy(a => a.Week).First());
                SowingTo = MyMapping.MapMonthWeekToDTO(aPlant.SewingMonths.OrderBy(a => a.MonthIndex).ThenBy(a => a.Week).Last());
            }
            else
            {

                SowingFrom = MyMapping.MapMonthWeekToDTO(aPlant.PlantType.SewingMonths.OrderBy(a => a.MonthIndex).ThenBy(a => a.Week).First());
                SowingTo = MyMapping.MapMonthWeekToDTO(aPlant.PlantType.SewingMonths.OrderBy(a => a.MonthIndex).ThenBy(a => a.Week).Last());
            }

            if(aPlant.HarvestMonths.Count > 0)
            {
                HarvestFrom = MyMapping.MapMonthWeekToDTO(aPlant.HarvestMonths.OrderBy(a => a.MonthIndex).ThenBy(a => a.Week).First());
                HarvestTo = MyMapping.MapMonthWeekToDTO(aPlant.HarvestMonths.OrderBy(a => a.MonthIndex).ThenBy(a => a.Week).Last());
            }
            else
            {

                HarvestFrom = MyMapping.MapMonthWeekToDTO(aPlant.PlantType.HarvestMonths.OrderBy(a => a.MonthIndex).ThenBy(a => a.Week).First());
                HarvestTo = MyMapping.MapMonthWeekToDTO(aPlant.PlantType.HarvestMonths.OrderBy(a => a.MonthIndex).ThenBy(a => a.Week).Last());
            }
        }
    }
}
