using API.Core;
using API.Relations;

namespace API.Services
{
    public interface IPestsService
    {
        Task<Result<List<PestRelation>>> GetPests();
    }
}
