using Microsoft.AspNetCore.Mvc;
using RecipeApi.Models;
using RecipeApi.Services;

namespace RecipeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeService _recipeService;

        public RecipeController(RecipeService recipeService)
        {
            _recipeService = recipeService;
        }
        

        [HttpGet]
        public IEnumerable<Recipe> GetRecipes()
        {
            return _recipeService.GetAllRecipes();
        }


        [HttpPost]
        public IActionResult CreateRecipe([FromBody] Recipe recipe)
        {
            // Here you would typically save the recipe to a database or perform other actions.
            // For this example, we'll just return the created recipe with a 201 Created status.

            _recipeService.AddRecipe(recipe); // Add the new recipe to the list

            if (recipe == null)
            {
                return BadRequest("Recipe cannot be null.");
            }

            return CreatedAtAction(nameof(GetRecipes), new { name = recipe.Name }, recipe);
        }

        [HttpGet("{id}")]
        public IActionResult GetRecipeById(int id)
        {
            var recipe = _recipeService.GetAllRecipes().FirstOrDefault(r => r.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRecipe(int id)
        {
            var recipe = _recipeService.GetAllRecipes().FirstOrDefault(r => r.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }
            _recipeService.DeleteRecipe(recipe); // Assuming you have a DeleteRecipe method in your service
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRecipe(int id, [FromBody] Recipe recipe)
        {
            var existingRecipe = _recipeService.GetAllRecipes().FirstOrDefault(r => r.Id == id);
            if (existingRecipe == null)
            {
                return NotFound();
            }

            existingRecipe.Name = recipe.Name;
            existingRecipe.CookingTime = recipe.CookingTime;
            existingRecipe.Difficulty = recipe.Difficulty;
            existingRecipe.Ingredients = recipe.Ingredients;

            return Ok(existingRecipe);
        }
    }

}