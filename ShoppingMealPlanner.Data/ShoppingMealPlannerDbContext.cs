using ShoppingMealPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace ShoppingMealPlanner.Data;

public class ShoppingMealPlannerDbContext : DbContext
{
    public ShoppingMealPlannerDbContext(DbContextOptions<ShoppingMealPlannerDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Conversion>()
            .HasOne(m => m.Unit)
            .WithMany(m => m.Conversions)
            .HasForeignKey(m => m.UnitId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<RecipeIngredient>()
            .HasOne(m => m.Unit)
            .WithMany(m => m.RecipeIngredients)
            .HasForeignKey(m => m.UnitId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Conversion> Conversions { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    public DbSet<Unit> Units { get; set; }
}