using API.Core;
using API.Domain;
using API.DTOs;
using API.Interfaces;
using API.Persistence;
using API.Relations;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
            var pests = await _context.Pests.ToListAsync();
            var pestsRelation = new List<PestRelation>();

            foreach (var pest in pests)
            {
                var pestRelation = new PestRelation
                {
                    PestDTO = new PestDTO
                    {
                        Advice = pest.Advice,
                        Id = pest.Id,
                        ImageSrc = pest.ImageSrc,
                        Name = pest.Name,
                    },
                    Plants = getPlantsForPlantType(pest.Plants)
                };
                pestsRelation.Add(pestRelation);
            }

            return Result<List<PestRelation>>.Success(pestsRelation);
        }

        private List<PlantDTO> getPlantsForPlantType(List<PlantType> plantTypes)
        {
            var plantsDTO = new List<PlantDTO>();
            foreach (var plantType in plantTypes)
            {
                var plants = _context.Plants.Where(a => a.PlantType == plantType).ToList();

                plantsDTO.AddRange(MyMapping.MapPlantsToDTO(plants));
            }

            return plantsDTO;
        }
    }
}
