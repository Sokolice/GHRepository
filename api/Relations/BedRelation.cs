using API.Core;
using API.DTOs;
using API.Domain;
using API.Persistence;
using NuGet.Packaging;

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
            /*var allAvoidPlants = new List<string>();

            foreach(var plantDTO in Plants)
            {
                var plant = context.Plants.Find(plantDTO.Id);
                var plantAvoids = plant.AvoidPlants.ToList();
                if(plantAvoids.Count > 0) { 
                    if (allAvoidPlants.Count == 0)
                        allAvoidPlants.AddRange(plantAvoids.Select(a=>a.Id.ToString()));
                    else
                    {
                    
                        allAvoidPlants.Union(plantAvoids.Select(a => a.Id.ToString()));
                    }
                }
            }

            AvoidPlantsIds = allAvoidPlants;*/

        }

        public void GetAllCompanionPlants(DataContext context)
        {

            /*var allCompanionPlants = new List<string>();

            foreach (var plantDTO in Plants)
            {
                var plant = context.Plants.Find(plantDTO.Id);
                var plantCompanions = plant.CompanionPlants.ToList();
                if(plantCompanions.Count > 0) { 
                    if (allCompanionPlants.Count == 0)
                        allCompanionPlants.AddRange(plantCompanions.Select(a=>a.Id.ToString()));
                    else
                    {
                        allCompanionPlants.Intersect(plantCompanions.Select(a => a.Id.ToString()));
                    }
                }
            }
            CompanionPlantsIds = allCompanionPlants;*/
        }
    }
}
