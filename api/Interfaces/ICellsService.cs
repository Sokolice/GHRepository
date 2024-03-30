using API.Core;
using API.Relations;
using Microsoft.AspNetCore.Mvc;

namespace API.Interfaces
{
    public interface ICellsService
    {
        Task<Result<List<Guid>>> DeleteCells(List<Guid> ids);
    }
}
