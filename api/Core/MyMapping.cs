using api.Model.DTOs;
using api.Model;

namespace api.Core
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
                    var task = new GardeningTaskDTO() { Description = obj.Description, Id = obj.Id, Name = obj.Name };
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
    }
}
