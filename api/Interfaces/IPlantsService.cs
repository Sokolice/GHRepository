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
        Task<Result<List<PlantTypePlantsRelation>>> GetAllAvailablePlantsByType();
        Task<Result<List<Guid>>> SavePlantsForUser(List<Guid> ids);
        Task<Result<List<PlantTypeDTO>>> GetAllPlantTypes();
        Task<Result<PlantDTO>> CreatePlant(PlantDTO plantDTO);
    }
}
