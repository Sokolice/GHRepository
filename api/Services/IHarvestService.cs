using API.Core;
using API.DTOs;

namespace API.Services
{
    public interface IHarvestService
    {
        Task<Result<HarvestDTO>> Harvest(HarvestDTO aHarvest);
    }
}
