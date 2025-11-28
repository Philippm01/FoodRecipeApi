using FoodRecipeApi.Data;
using Microsoft.EntityFrameworkCore;
using FoodRecipeApi.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = Environment.GetEnvironmentVariable("DefaultConnection")
    ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<FoodRecipeContext>(options =>
    options.UseNpgsql(connectionString));

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

// Create a new recipe
app.MapPost("/api/recipes", async (RecipesEnDto recipe, FoodRecipeContext db) =>
{
    db.RecipesEn.Add(recipe);
    await db.SaveChangesAsync();
    return Results.Created($"/api/recipes/{recipe.Id}", recipe);
})
.WithName("CreateRecipe")
.WithOpenApi();

// Update a recipe
app.MapPut("/api/recipes/{id}", async (long id, RecipesEnDto updatedRecipe, FoodRecipeContext db) =>
{
    var recipe = await db.RecipesEn.FindAsync(id);
    if (recipe is null) return Results.NotFound();

    db.Entry(recipe).CurrentValues.SetValues(updatedRecipe);
    await db.SaveChangesAsync();
    return Results.Ok(recipe);
})
.WithName("UpdateRecipe")
.WithOpenApi();

// Patch a recipe (partial update)
app.MapPatch("/api/recipes/{id}", async (long id, RecipesEnDto patchRecipe, FoodRecipeContext db) =>
{
    var recipe = await db.RecipesEn.FindAsync(id);
    if (recipe is null) return Results.NotFound();

    // Example: patch only non-null values
    foreach (var prop in typeof(RecipesEnDto).GetProperties())
    {
        var value = prop.GetValue(patchRecipe);
        if (value != null)
            prop.SetValue(recipe, value);
    }
    await db.SaveChangesAsync();
    return Results.Ok(recipe);
})
.WithName("PatchRecipe")
.WithOpenApi();

// Delete a recipe
app.MapDelete("/api/recipes/{id}", async (long id, FoodRecipeContext db) =>
{
    var recipe = await db.RecipesEn.FindAsync(id);
    if (recipe is null) return Results.NotFound();
    db.RecipesEn.Remove(recipe);
    await db.SaveChangesAsync();
    return Results.NoContent();
})
.WithName("DeleteRecipe")
.WithOpenApi();

// Create a new wholefood
app.MapPost("/api/wholefoods", async (WholefoodEnDto wholefood, FoodRecipeContext db) =>
{
    db.WholefoodEn.Add(wholefood);
    await db.SaveChangesAsync();
    return Results.Created($"/api/wholefoods/{wholefood.Id}", wholefood);
})
.WithName("CreateWholefood")
.WithOpenApi();

// Update a wholefood
app.MapPut("/api/wholefoods/{id}", async (long id, WholefoodEnDto updatedWholefood, FoodRecipeContext db) =>
{
    var wholefood = await db.WholefoodEn.FindAsync(id);
    if (wholefood is null) return Results.NotFound();

    db.Entry(wholefood).CurrentValues.SetValues(updatedWholefood);
    await db.SaveChangesAsync();
    return Results.Ok(wholefood);
})
.WithName("UpdateWholefood")
.WithOpenApi();

// Patch a wholefood (partial update)
app.MapPatch("/api/wholefoods/{id}", async (long id, WholefoodEnDto patchWholefood, FoodRecipeContext db) =>
{
    var wholefood = await db.WholefoodEn.FindAsync(id);
    if (wholefood is null) return Results.NotFound();

    foreach (var prop in typeof(WholefoodEnDto).GetProperties())
    {
        var value = prop.GetValue(patchWholefood);
        if (value != null)
            prop.SetValue(wholefood, value);
    }
    await db.SaveChangesAsync();
    return Results.Ok(wholefood);
})
.WithName("PatchWholefood")
.WithOpenApi();

// Delete a wholefood
app.MapDelete("/api/wholefoods/{id}", async (long id, FoodRecipeContext db) =>
{
    var wholefood = await db.WholefoodEn.FindAsync(id);
    if (wholefood is null) return Results.NotFound();
    db.WholefoodEn.Remove(wholefood);
    await db.SaveChangesAsync();
    return Results.NoContent();
})
.WithName("DeleteWholefood")
.WithOpenApi();

app.Run();
