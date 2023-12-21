using api.Model;
using api.DTOs;
using api.Relations;

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
                Cells = bedRelation.Cells
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
            };
            bedRelation.Cells = aBed.Cells.OrderBy(x => x.Y).ToList().OrderBy(x => x.X).ToList();

            return bedRelation;
        }
    }
}
