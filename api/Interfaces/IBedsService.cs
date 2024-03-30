using API.Core;
using API.Relations;
using Microsoft.AspNetCore.Mvc;

namespace API.Interfaces
{
    public interface IBedsService
    {
        Task<Result<List<BedRelation>>> GetBeds();
        Task<Result<BedRelation>> PostBed(BedRelation bedRelation);
        Task<Result<Guid>> DeleteBed(Guid id);
        Task<Result<BedRelation>> GetBed(Guid id);
        Task<Result<BedRelation>> UpdateBed(Guid id, BedRelation bedRelation);
    }
}
