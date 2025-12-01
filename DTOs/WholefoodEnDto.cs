namespace FoodRecipeApi.DTOs;

    public class WholefoodEnDto
    {
        public long Id { get; set; } 
        public required string Name { get; set; } 
        public int? Calories { get; set; } 
        public double? Carbohydrates { get; set; } 
        public double? Fats { get; set; } 
        public double? Protein { get; set; } 
    }
