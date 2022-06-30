using System.ComponentModel.DataAnnotations;

namespace ShoppingMealPlanner.Models;

public class Recipe
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public ICollection<RecipeIngredient>? RecipeIngredients { get; set; }
}