using FoodRecipeApi.DTOs;
using Microsoft.EntityFrameworkCore;
using FoodRecipeApi.Models;

namespace FoodRecipeApi.Data;

public class FoodRecipeContext : DbContext
{
    public FoodRecipeContext(DbContextOptions<FoodRecipeContext> options) : base(options)
    {
    }

    public DbSet<WholefoodEnDto> WholefoodEn { get; set; }
    public DbSet<RecipesEnDto> RecipesEn { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Wholefood> Wholefoods { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<WholefoodEnDto>().ToTable("wholefood_en");
        modelBuilder.Entity<RecipesEnDto>().ToTable("recipes_en");

        modelBuilder.Entity<WholefoodEnDto>().HasKey(w => w.Id);
        modelBuilder.Entity<RecipesEnDto>().HasKey(r => r.Id);

        modelBuilder.Entity<WholefoodEnDto>()
            .Property(w => w.Id).HasColumnName("id");
        modelBuilder.Entity<WholefoodEnDto>()
            .Property(w => w.Name).HasColumnName("name").HasMaxLength(255);
        modelBuilder.Entity<WholefoodEnDto>()
            .Property(w => w.Calories).HasColumnName("calories");
        modelBuilder.Entity<WholefoodEnDto>()
            .Property(w => w.Carbohydrates).HasColumnName("carbohydrates");
        modelBuilder.Entity<WholefoodEnDto>()
            .Property(w => w.Fats).HasColumnName("fats");
        modelBuilder.Entity<WholefoodEnDto>()
            .Property(w => w.Protein).HasColumnName("protein");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Id).HasColumnName("id");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Name).HasColumnName("name").HasMaxLength(255).IsRequired();
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Calories).HasColumnName("calories");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Carbohydrates).HasColumnName("carbohydrates");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Fats).HasColumnName("fats");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Protein).HasColumnName("protein");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Description).HasColumnName("description");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Ingredients).HasColumnName("ingredients").IsRequired();
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.PortionSize).HasColumnName("portion_size");
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.PreparationTime).HasColumnName("preparation_time").IsRequired();
        modelBuilder.Entity<RecipesEnDto>()
            .Property(r => r.Difficulty).HasColumnName("difficulty");
    }
}
