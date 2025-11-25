using FoodRecipeApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<FoodRecipeContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Get all whole foods
app.MapGet("/api/wholefoods", async (FoodRecipeContext db) =>
{
    return await db.WholefoodEn.ToListAsync();
})
.WithName("GetWholefoods")
.WithOpenApi();

// Get whole food by id
app.MapGet("/api/wholefoods/{id}", async (long id, FoodRecipeContext db) =>
{
    var food = await db.WholefoodEn.FindAsync(id);
    return food is null ? Results.NotFound() : Results.Ok(food);
})
.WithName("GetWholefoodById")
.WithOpenApi();

// Get all recipes
app.MapGet("/api/recipes", async (FoodRecipeContext db) =>
{
    return await db.RecipesEn.ToListAsync();
})
.WithName("GetRecipes")
.WithOpenApi();

// Get recipe by id
app.MapGet("/api/recipes/{id}", async (long id, FoodRecipeContext db) =>
{
    var recipe = await db.RecipesEn.FindAsync(id);
    return recipe is null ? Results.NotFound() : Results.Ok(recipe);
})
.WithName("GetRecipeById")
.WithOpenApi();

app.Run();
