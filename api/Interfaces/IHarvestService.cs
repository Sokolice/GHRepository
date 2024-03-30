using API.Core;
using API.DTOs;

namespace API.Interfaces
{
    public interface IHarvestService
    {
        Task<Result<HarvestDTO>> Harvest(HarvestDTO aHarvest);
    }
}
