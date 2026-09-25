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

    public async Task<List<Recipe>> GetAllRecipesAsync()
    {
        return await _context.Recipes.Include(r => r.Ingredients).ToListAsync();
    }

    public async Task AddRecipeAsync(Recipe recipe)
    {
        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRecipeAsync(Recipe recipe)
    {
        _context.Recipes.Remove(recipe);
        await _context.SaveChangesAsync();
    }

    public async Task<Recipe?> GetRecipeByIdAsync(int id)
    {
        return await _context.Recipes.Include(r => r.Ingredients).FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task DeleteRecipeByIdAsync(int id)
    {
        var recipe = await GetRecipeByIdAsync(id);
        if (recipe != null)
        {
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateRecipeAsync(Recipe recipe)
    {
        _context.Recipes.Update(recipe);
        await _context.SaveChangesAsync();
    }
}