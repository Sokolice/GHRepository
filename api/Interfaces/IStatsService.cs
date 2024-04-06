using API.Core;
using API.DTOs;
using API.Model;

namespace API.Interfaces
{
    public interface IStatsService
    {
        Task<Result<StatsDTO>> GetStats();
    }
}
