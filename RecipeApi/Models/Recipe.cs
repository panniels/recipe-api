namespace RecipeApi.Models

{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; } ="";
        public int CookingTime { get; set; }
        public string Difficulty { get; set; } = "";

        public string Cuisine { get; set; } = "";
        public List<string> Instructions { get; set; } = [];

        public string? ImageUrl { get; set; } = "";
        public List<Ingredient> Ingredients { get; set; } = [];
    }
}