using API.Core;
using API.Model;

namespace API.Interfaces
{
    public interface IStatsService
    {
        Task<Result<Stats>> GetStats();
    }
}
