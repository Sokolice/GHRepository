using API.Core;
using API.Relations;

namespace API.Interfaces
{
    public interface IPestsService
    {
        Task<Result<List<PestRelation>>> GetPests();
    }
}
