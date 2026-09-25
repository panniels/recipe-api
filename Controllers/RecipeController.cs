using Microsoft.AspNetCore.Mvc;
using RecipeApi.Models;

namespace RecipeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private static List<Recipe> _recipes = new();
        

        [HttpGet]
        public IEnumerable<Recipe> GetRecipes()
        {
            return _recipes;
        }


        [HttpPost]
        public IActionResult CreateRecipe([FromBody] Recipe recipe)
        {
            // Here you would typically save the recipe to a database or perform other actions.
            // For this example, we'll just return the created recipe with a 201 Created status.

            _recipes.Add(recipe); // Add the new recipe to the list

            return CreatedAtAction(nameof(GetRecipes), new { name = recipe.Name }, recipe);
        }
    }
}