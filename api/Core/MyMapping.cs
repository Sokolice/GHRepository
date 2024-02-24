using API.Model;
using API.DTOs;
using API.Relations;
using System.Numerics;
using System.Collections.Generic;
using Microsoft.OpenApi.Validations;

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
                    plantDTOs.Add(new PlantDTO(obj));
                }
            }

            return plantDTOs;
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
                mapedPlants.Add(new PlantRecordDTO(plant));
            };

            return mapedPlants;
        }

    }
}
