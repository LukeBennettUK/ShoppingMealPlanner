using System.ComponentModel.DataAnnotations;

namespace ShoppingMealPlanner.Models;

public class Brand
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = String.Empty;

    public ICollection<Ingredient>? Ingredients { get; set; }
}