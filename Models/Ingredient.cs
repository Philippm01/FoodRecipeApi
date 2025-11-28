namespace FoodRecipeApi.Models
{
    public class Wholefood
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public int? Calories { get; set; }
        public double? Carbohydrates { get; set; }
        public double? Fats { get; set; }
        public double? Protein { get; set; }
        public double? Fiber { get; set; }
        public double? Sugar { get; set; }
        public double? SaturatedFattyAcids { get; set; }
        public double? UnsaturatedFattyAcids { get; set; }
        public double? TransFat { get; set; }
        public double? Sodium { get; set; }
        public double? Cholesterol { get; set; }
        public int? PortionSize { get; set; }
        public string? Brand { get; set; }
        public int? Popularity { get; set; }
        public int? Verified { get; set; }
        public string? Country { get; set; }
        public int? Icon { get; set; }

        public long RecipeId { get; set; }
        public Recipe Recipe { get; set; } = null!;
    }
}
