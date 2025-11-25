using FoodRecipeApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace FoodRecipeApi.Data;

public class FoodRecipeContext : DbContext
{
    public FoodRecipeContext(DbContextOptions<FoodRecipeContext> options) : base(options)
    {
    }

    public DbSet<WholefoodEnDto> WholefoodEn { get; set; }
    public DbSet<RecipesEnDto> RecipesEn { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Map to existing tables
        modelBuilder.Entity<WholefoodEnDto>().ToTable("wholefood_en");
        modelBuilder.Entity<RecipesEnDto>().ToTable("recipes_en");

        // Configure primary keys
        modelBuilder.Entity<WholefoodEnDto>().HasKey(w => w.Id);
        modelBuilder.Entity<RecipesEnDto>().HasKey(r => r.Id);

        // Map properties to lowercase column names for WholefoodEnDto
        modelBuilder.Entity<WholefoodEnDto>()
            .Property(w => w.Id).HasColumnName("id");
        modelBuilder.Entity<WholefoodEnDto>()
            .Property(w => w.Name).HasColumnName("name");
        modelBuilder.Entity<WholefoodEnDto>()
            .Property(w => w.Calories).HasColumnName("calories");
        modelBuilder.Entity<WholefoodEnDto>()
            .Property(w => w.Carbohydrates).HasColumnName("carbohydrates");
        modelBuilder.Entity<WholefoodEnDto>()
            .Property(w => w.Fats).HasColumnName("fats");
        modelBuilder.Entity<WholefoodEnDto>()
            .Property(w => w.Protein).HasColumnName("protein");
        modelBuilder.Entity<WholefoodEnDto>()
            .Property(w => w.Fiber).HasColumnName("fiber");
        modelBuilder.Entity<WholefoodEnDto>()
            .Property(w => w.Sugar).HasColumnName("sugar");
        modelBuilder.Entity<WholefoodEnDto>()
            .Property(w => w.SaturatedFattyAcids).HasColumnName("saturated_fatty_acids");
        modelBuilder.Entity<WholefoodEnDto>()
            .Property(w => w.UnsaturatedFattyAcids).HasColumnName("unsaturated_fatty_acids");
        modelBuilder.Entity<WholefoodEnDto>()
            .Property(w => w.TransFat).HasColumnName("trans_fat");
        modelBuilder.Entity<WholefoodEnDto>()
            .Property(w => w.Sodium).HasColumnName("sodium");
        modelBuilder.Entity<WholefoodEnDto>()
            .Property(w => w.Cholesterol).HasColumnName("cholesterol");
        modelBuilder.Entity<WholefoodEnDto>()
            .Property(w => w.PortionSize).HasColumnName("portion_size");
        modelBuilder.Entity<WholefoodEnDto>()
            .Property(w => w.Brand).HasColumnName("brand");
        modelBuilder.Entity<WholefoodEnDto>()
            .Property(w => w.Popularity).HasColumnName("popularity");
        modelBuilder.Entity<WholefoodEnDto>()
            .Property(w => w.Verified).HasColumnName("verified");
        modelBuilder.Entity<WholefoodEnDto>()
            .Property(w => w.Country).HasColumnName("country");
        modelBuilder.Entity<WholefoodEnDto>()
            .Property(w => w.Icon).HasColumnName("icon");

        // Map properties to lowercase column names for RecipesEnDto
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Id).HasColumnName("id");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Name).HasColumnName("name");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Calories).HasColumnName("calories");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Carbohydrates).HasColumnName("carbohydrates");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Fats).HasColumnName("fats");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Protein).HasColumnName("protein");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Fiber).HasColumnName("fiber");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Sugar).HasColumnName("sugar");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.SaturatedFattyAcids).HasColumnName("saturated_fatty_acids");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Brand).HasColumnName("brand");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Popularity).HasColumnName("popularity");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Verified).HasColumnName("verified");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Country).HasColumnName("country");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Icon).HasColumnName("icon");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Description).HasColumnName("description");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Steps).HasColumnName("steps");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Ingredients).HasColumnName("ingredients");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.PortionSize).HasColumnName("portion_size");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.PreparationTime).HasColumnName("preparation_time");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Difficulty).HasColumnName("difficulty");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.ImagePath).HasColumnName("image_path");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Vegan).HasColumnName("vegan");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Vegetarian).HasColumnName("vegetarian");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Pescetarian).HasColumnName("pescetarian");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.HighProtein).HasColumnName("high_protein");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.LowCarb).HasColumnName("low_carb");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Keto).HasColumnName("keto");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Normal).HasColumnName("normal");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Type).HasColumnName("type");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.OriginCountry).HasColumnName("origin_country");
    }
}
