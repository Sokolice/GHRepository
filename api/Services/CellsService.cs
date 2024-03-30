using API.Core;
using API.Interfaces;
using API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace API.Services
{
    public class CellsService : ICellsService
    {
        private readonly DataContext _context;
        public CellsService(DataContext context)
        {

            _context = context;
        }

        public async Task<Result<List<Guid>>> DeleteCells(List<Guid> ids)
        {
            var cells = _context.Cells.Where(c => ids.Contains(c.Id));
                _context.Cells.RemoveRange(cells);
            var result = await _context.SaveChangesAsync() > 0;


            if (!result) 
                return Result<List<Guid>>.Failure("Failed to delete activity", false);

            return Result<List<Guid>>.Success(ids);
           
        }
    }
}
