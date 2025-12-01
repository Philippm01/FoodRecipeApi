namespace FoodRecipeApi.DTOs;

    public class RecipesEnDto
    {
        public long Id { get; set; }
        public required string Name { get; set; } 
        public int? Calories { get; set; } 
        public double? Carbohydrates { get; set; } 
        public double? Fats { get; set; } 
        public double? Protein { get; set; } 
        public required string Description { get; set; } 
        public required string Ingredients { get; set; } 
        public int? PortionSize { get; set; } 
        public int? PreparationTime { get; set; } 
        public int? Difficulty { get; set; } 
    }
