using RecipeApi.Models;
using RecipeApi.Data;
using Microsoft.EntityFrameworkCore;

namespace RecipeApi.Services;

public class RecipeService
{
    private readonly RecipeDBContext _context;

    public RecipeService(RecipeDBContext context)
    {
        _context = context;
    }

    public List<Recipe> GetAllRecipes()
    {
        return _context.Recipes.Include(r => r.Ingredients).ToList();
    }

    public void AddRecipe(Recipe recipe)
    {
        _context.Recipes.Add(recipe);
        _context.SaveChanges();
    }

    public void DeleteRecipe(Recipe recipe)
    {
        _context.Recipes.Remove(recipe);
        _context.SaveChanges();
    }

    public Recipe? GetRecipeById(int id)
    {
        return _context.Recipes.Include(r => r.Ingredients).FirstOrDefault(r => r.Id == id);
    }

    public void DeleteRecipeById(int id)
    {
        var recipe = GetRecipeById(id);
        if (recipe != null)
        {
            _context.Recipes.Remove(recipe);
            _context.SaveChanges();
        }
    }
}