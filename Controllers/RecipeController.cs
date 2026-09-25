using Microsoft.AspNetCore.Mvc;
using RecipeApi.Models;

namespace RecipeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Recipe> GetRecipes()
        {
            return new List<Recipe>
            {
                new Recipe
                {
                    Name = "Test Recipe",
                    CookingTime = 30,
                    Difficulty = "Medium",
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Name = "Flour", Quantity = 2, Unit = "cups" },
                        new Ingredient { Name = "Sugar", Quantity = 1, Unit = "cup" },
                        new Ingredient { Name = "Eggs", Quantity = 3, Unit = "pieces" }
                    }
                },
                new Recipe
                {
                    Name = "Another Recipe",
                    CookingTime = 45,
                    Difficulty = "Hard",
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Name = "Butter", Quantity = 1, Unit = "stick" },
                        new Ingredient { Name = "Milk", Quantity = 2, Unit = "cups" },
                        new Ingredient { Name = "Vanilla Extract", Quantity = 1, Unit = "teaspoon" }
                    }
                }
            };
        }
    }
}