using API.Core;
using API.DTOs;
using API.Domain;
using API.Persistence;
using NuGet.Packaging;
using Microsoft.EntityFrameworkCore;
using Castle.DynamicProxy.Generators;

namespace API.Relations
{
    public class BedRelation
    {
        public BedDTO Bed {  get; set; }
        public List<Cell> Cells { get; set; }
        public List<PlantDTO> Plants { get; set; }
        public List<string> AvoidPlantsIds { get; set; }
        public List<string> CompanionPlantsIds { get; set; }

        public BedRelation()
        {
            Cells = new List<Cell>();
            Bed = new BedDTO();
            Plants = new List<PlantDTO>();
            AvoidPlantsIds = new List<string>();
            CompanionPlantsIds = new List<string>();
        }

        public BedRelation(Bed aBed)
        {
            Bed = new BedDTO(aBed);
            Cells = aBed.Cells.OrderBy(x => x.Y).ToList().OrderBy(x => x.X).ToList();
            //Plants = MyMapping.MapPlantsToDTO(aBed.Cells.);
            AvoidPlantsIds = new List<string>();
            CompanionPlantsIds = new List<string>();
        }


        public void GetAllAvoidPlants(DataContext context)
        {
            var allAvoidPlants = new List<string>();

            foreach(var plantDTO in Plants)
            {
                var avoidPlantTypes = context.PlantTypes.Find(plantDTO.PlantTypeId).AvoidPlantTypes.ToList();
                if(avoidPlantTypes.Count > 0) { 
                    foreach(var avoid in avoidPlantTypes)
                    {
                        if (allAvoidPlants.Count == 0)
                            allAvoidPlants.AddRange(context.Plants.Where(a => a.PlantType == avoid).Select(a => a.Id.ToString().ToLower()).ToList());
                        else 
                            allAvoidPlants = allAvoidPlants.Union(context.Plants.Where(a => a.PlantType == avoid).Select(a => a.Id.ToString().ToLower()).ToList()).ToList();                        
                    }
                }
            }

            AvoidPlantsIds = allAvoidPlants;
        }

        public void GetAllCompanionPlants(DataContext context)
        {

            var allCompanionPlants = new List<string>();

            foreach (var plantDTO in Plants)
            {
                var plantCompanions = context.PlantTypes.Find(plantDTO.PlantTypeId).CompanionPlantTypes.ToList();
                if (plantCompanions.Count > 0)
                {
                    foreach (var companion in plantCompanions)
                    {

                        if (allCompanionPlants.Count == 0)
                            allCompanionPlants.AddRange(context.Plants.Where(a => a.PlantType == companion).Select(a => a.Id.ToString().ToLower()).ToList());
                        else 
                            allCompanionPlants = allCompanionPlants.Union(context.Plants.Where(a => a.PlantType == companion).Select(a => a.Id.ToString().ToLower()).ToList()).ToList();
                    }
                }
            }
            CompanionPlantsIds = allCompanionPlants;
        }
    }
}
