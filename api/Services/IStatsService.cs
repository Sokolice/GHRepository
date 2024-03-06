using API.Core;
using API.Model;

namespace API.Services
{
    public interface IStatsService
    {
        Task<Result<Stats>> GetStats();
    }
}
