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
        public async Task<IActionResult> GetRecipes()
        {
            var recipes = await _recipeService.GetAllRecipesAsync();
            return Ok(recipes);
        }


        [HttpPost]
        public async Task<IActionResult> CreateRecipe([FromBody] Recipe recipe)
        {
            if (recipe == null)
            {
                return BadRequest("Recipe cannot be null.");
            }

            await _recipeService.AddRecipeAsync(recipe); 

            return CreatedAtAction(nameof(GetRecipeById), new { id = recipe.Id }, recipe);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipeById(int id)
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            await _recipeService.DeleteRecipeByIdAsync(id);
            return NoContent();
        }

        [HttpPost("{id}/image")]
        public async Task<IActionResult> UploadImage(int id, IFormFile file)
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(id);
            if (recipe == null)
                return NotFound();

            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            Directory.CreateDirectory(uploadsFolder);

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            recipe.ImageUrl = $"/images/{fileName}";
            await _recipeService.UpdateRecipeAsync(recipe);

            return Ok(recipe);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipe(int id, [FromBody] Recipe recipe)
        {
            var existingRecipe = await _recipeService.GetRecipeByIdAsync(id);
            if (existingRecipe == null)
            {
                return NotFound();
            }

            existingRecipe.Name = recipe.Name;
            existingRecipe.CookingTime = recipe.CookingTime;
            existingRecipe.Difficulty = recipe.Difficulty;
            existingRecipe.Ingredients = recipe.Ingredients;

            await _recipeService.UpdateRecipeAsync(existingRecipe);
            return Ok(existingRecipe);
        }
    }

}