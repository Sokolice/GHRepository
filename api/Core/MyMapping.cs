using API.Domain;
using API.DTOs;

namespace API.Core
{
    public static class MyMapping
    {
        public static BedDTO MapBedToDTO(Bed bed)
        {
            return new BedDTO
            {
                CropRotation = bed.CropRotation,
                Id = bed.Id,
                IsDesign = bed.IsDesign,
                Length = bed.Length,
                Name = bed.Name,
                Note = bed.Note,
                NumOfColumns = bed.NumOfColumns,
                NumOfRows = bed.NumOfRows,
                Width = bed.Width
            };
        }

        public static MonthWeekDTO MapMonthWeekToDTO (MonthWeek mw)
        {
            return new MonthWeekDTO
            {
                Month = mw.Month,
                Week = mw.Week,
                MonthIndex = mw.MonthIndex
            };
        }

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

        public static List<PlantDTO> MapPlantsToDTO(List<Plant> list)
        {
            var plantDTOs = new List<PlantDTO>();
            if (list != null)
            {
                foreach (Plant obj in list)
                {
                    plantDTOs.Add(new PlantDTO(obj));
                }
            }

            return plantDTOs;
        }

        /*public static List<PlantDTO> MapPlantTypesFromDTO(List<PlantType> list)
        {
            var plantDTOs = new List<PlantDTO>();
            if (list != null)
            {
                foreach (PlantType obj in list)
                {
                    plantDTOs.Add(new PlantDTO(obj));
                }
            }

            return plantDTOs;

        }

        public static PlantDTO MapPlantFromPlantType(PlantType plantType)
        {

        }*/

            public static List<MonthWeekDTO> MapMonthWeeksToDTOs(List<MonthWeek> list)
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


        public static List<PlantRecordDTO> MapPlantRecordsList(List<PlantRecord> plants)
        {

            List<PlantRecordDTO> mapedPlants = new List<PlantRecordDTO>();

            foreach (var plant in plants)
            {
                mapedPlants.Add(new PlantRecordDTO(plant));
            };

            return mapedPlants;
        }

    }
}
