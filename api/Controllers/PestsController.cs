using API.Core;
using API.DTOs;
using API.Persistence;
using API.Relations;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PestsController : Controller
    {
        private readonly DataContext _context;

        public PestsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<PestRelation> GetPests()
        {
            var plants = _context.Pests.ToList();

            var pests = _context.Pests.Select(a => new PestRelation
            {
                PestDTO = new PestDTO 
                { 
                    Advice = a.Advice, 
                    Name = a.Name,
                    Id = a.Id,
                    ImageSrc = a.ImageSrc
                },
                Plants = MyMapping.MapPlantsFromDTO(a.Plants)
                
            }).ToList();

            return pests;
        }
    }
}
