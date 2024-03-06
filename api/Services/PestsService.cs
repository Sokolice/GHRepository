using API.Core;
using API.DTOs;
using API.Persistence;
using API.Relations;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class PestsService : IPestsService
    {
        private readonly DataContext _context;

        public PestsService(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<List<PestRelation>>> GetPests()
        {
            var pests = await _context.Pests.Select(a => new PestRelation
            {
                PestDTO = new PestDTO
                {
                    Advice = a.Advice,
                    Name = a.Name,
                    Id = a.Id,
                    ImageSrc = a.ImageSrc
                },
                Plants = MyMapping.MapPlantsFromDTO(a.Plants)

            }).ToListAsync();

            return Result<List<PestRelation>>.Success(pests);
        }
    }
}
