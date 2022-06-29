namespace ShoppingMealPlanner.Models;

public class Brand
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;

    public ICollection<Ingredient>? Ingredients { get; set; }
}