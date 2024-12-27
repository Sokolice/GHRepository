using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Recipes.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class RecipesController : ControllerBase
    {
       

        private readonly ILogger<RecipesController> _logger;

        public RecipesController(ILogger<RecipesController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{name}")]
        public List<Recipe> GetRecipes(string name)
        {
            var recipes = new List<Recipe>();


            recipes = ApetiteParser.GetRecipesByIngredient(name);



            return recipes;
        }
    }
}