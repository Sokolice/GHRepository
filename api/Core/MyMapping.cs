using API.Model;
using API.DTOs;
using API.Relations;
using System.Numerics;
using System.Collections.Generic;

namespace API.Core
{
    public static class MyMapping
    {

        public static List<GardeningTaskDTO> MapGardeningTasks(List<GardeningTask> list)
        {
            var gardeningTaskDTOs = new List<GardeningTaskDTO>();
            if (list != null)
            {
                foreach (GardeningTask obj in list)
                {
                    var task = new GardeningTaskDTO() { Id = obj.Id, Name = obj.Name };
                    gardeningTaskDTOs.Add(task);
                }
            }

            return gardeningTaskDTOs;
        }

        public static List<PlantDTO> MapPlants(List<Plant> list)
        {
            var plantDTOs = new List<PlantDTO>();
            if (list != null)
            {
                foreach (Plant obj in list)
                {
                    var plant = new PlantDTO() {
                        CropRotation = obj.CropRotation,
                        Description = obj.Description,
                        DirectSewing    = obj.DirectSewing,
                        GerminationTemp = obj.GerminationTemp,  
                        Id  = obj.Id,
                        Name = obj.Name,    
                        ImageSrc = obj.ImageSrc,
                        IsHybrid = obj.IsHybrid,
                        RepeatedPlanting = obj.RepeatedPlanting                         
                    };

                    plantDTOs.Add(plant);
                }
            }

            return plantDTOs;
        }

        public static Bed MapBed(BedRelation bedRelation)
        {
            var bed = new Bed()
            {
                Id = bedRelation.Bed.Id,
                Name = bedRelation.Bed.Name,
                Length = bedRelation.Bed.Length,
                Width = bedRelation.Bed.Width,
                NumOfColumns = bedRelation.Bed.NumOfColumns,
                NumOfRows = bedRelation.Bed.NumOfRows,
                Cells = bedRelation.Cells,
                isDesign = bedRelation.Bed.isDesign,
                CropRotation = bedRelation.Bed.CropRotation
            };

            return bed;
        }

        public static BedRelation MapBedRelation(Bed aBed)
        {
            var bedRelation = new BedRelation();
            bedRelation.Bed = new BedDTO
            {
                Id = aBed.Id,
                Name = aBed.Name,
                Length = aBed.Length,
                NumOfColumns = aBed.NumOfColumns,
                NumOfRows = aBed.NumOfRows,
                Width = aBed.Width,
                isDesign = aBed.isDesign,
                CropRotation = aBed.CropRotation
            };
            bedRelation.Cells = aBed.Cells.OrderBy(x => x.Y).ToList().OrderBy(x => x.X).ToList();

            return bedRelation;
        }

        public static List<MonthWeekDTO> MapMonthWeeks(List<MonthWeek> list)
        {
            var monthweeksDTOs = new List<MonthWeekDTO>();
            if (list != null)
            {
                foreach (MonthWeek obj in list)
                {
                    var task = new MonthWeekDTO() {Month = obj.Month, MonthIndex = obj.MonthIndex, Week = obj.Week };
                    monthweeksDTOs.Add(task);
                }
            }

            return monthweeksDTOs;
        }
                
        public static PlantRecordDTO MapPlantRecord(PlantRecord aPlant)
        {
            var plantRecordDTO = new PlantRecordDTO
            {
                Id = aPlant.Id,
                AmountPlanted = aPlant.AmountPlanted,
                DatePlanted = aPlant.DatePlanted,
                PlantId = aPlant.PlantId
            };

            PlantRecordDTO.CalculatePresumedHarvest(plantRecordDTO, aPlant.Plant);
            PlantRecordDTO.calculateProgress(plantRecordDTO);

            return plantRecordDTO;
        }

        public static List<PlantDTO> MapPlantList(List<Plant> plants){

            List<PlantDTO> mapedPlants = new List<PlantDTO>();

            foreach(var plant in plants)
            {
                var mapedPlant = new PlantDTO(plant);

                mapedPlants.Add(mapedPlant);
            };

            return mapedPlants;
        }

        public static List<PlantRecordDTO> MapPlantRecordsList(List<PlantRecord> plants)
        {

            List<PlantRecordDTO> mapedPlants = new List<PlantRecordDTO>();

            foreach (var plant in plants)
            {
                var mapedPlant = MapPlantRecord(plant);

                mapedPlants.Add(mapedPlant);
            };

            return mapedPlants;
        }

    }
}
