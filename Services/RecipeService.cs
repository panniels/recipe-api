using RecipeApi.Models;

namespace RecipeApi.Services;

public class RecipeService
{
    private readonly List<Recipe> _recipes = new ();

    public List<Recipe> GetAllRecipes()
    {
        return _recipes;
    }

    public void AddRecipe(Recipe recipe)
    {
        _recipes.Add(recipe);
    }

    public void DeleteRecipe(Recipe recipe)
    {
        _recipes.Remove(recipe);
    }
}