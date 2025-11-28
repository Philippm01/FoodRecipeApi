namespace FoodRecipeApi.DTOs;

public class RecipesEnDto
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
    public string? Brand { get; set; }
    public int? Popularity { get; set; }
    public bool? Verified { get; set; }
    public string? Country { get; set; }
    public int? Icon { get; set; }
    public string? Description { get; set; }
    public string? Steps { get; set; }
    public string? Ingredients { get; set; }
    public int? PortionSize { get; set; }
    public int PreparationTime { get; set; }
    public int? Difficulty { get; set; }
    public string? ImagePath { get; set; }
    public bool Vegan { get; set; }
    public bool Vegetarian { get; set; }
    public bool Pescetarian { get; set; }
    public bool HighProtein { get; set; }
    public bool LowCarb { get; set; }
    public bool Keto { get; set; }
    public bool Normal { get; set; }
    public string? Type { get; set; }
    public string? OriginCountry { get; set; }
}
