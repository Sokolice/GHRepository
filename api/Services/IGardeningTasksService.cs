using API.Core;
using API.DTOs;
using API.Relations;

namespace API.Services
{
    public interface IGardeningTasksService
    {
        Task<Result<List<MonthTaskRelation>>> GetTasks();
        Task<Result<GardeningTaskDTO>> PostGardeningTasks(GardeningTaskDTO gardeningTask);
    }
}
