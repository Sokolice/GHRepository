using API.Domain;
using API.DTOs;

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

        public static List<PlantDTO> MapPlantsFromDTO(List<Plant> list)
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
