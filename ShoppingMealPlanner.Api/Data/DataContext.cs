using Microsoft.EntityFrameworkCore;
using ShoppingMealPlanner.Api.Models;

namespace ShoppingMealPlanner.Api.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Conversion> Conversions { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    public DbSet<Unit> Units { get; set; }
}