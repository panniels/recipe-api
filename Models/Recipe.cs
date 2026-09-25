namespace RecipeApi.Models

{
    public class Recipe
    {
        public string Name { get; set; } ="";
        public int CookingTime { get; set; }
        public string Difficulty { get; set; } = "";
        public List<Ingredient> Ingredients { get; set; } = [];
    }
}