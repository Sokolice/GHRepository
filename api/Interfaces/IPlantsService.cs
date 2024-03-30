using API.Core;
using API.DTOs;
using API.Relations;

namespace API.Interfaces
{
    public interface IPlantsService
    {
        Task<Result<List<PlantDTO>>> GetPlants();
        Task<Result<PlantDTO>> GetPlant(Guid id);
        Task<Result<PlantPlantsRelation>> GetOtherPlants(Guid id);
        Task<Result<List<PlantPlantsRelation>>> GetAllPlantsRelations();
    }
}
