using API.Core;
using API.Relations;
using Microsoft.AspNetCore.Mvc;

namespace API.Services
{
    public interface ICellsService
    {
        Task<Result<List<Guid>>> DeleteCells(List<Guid> ids);
    }
}
