namespace ShoppingMealPlanner.Models;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public int Quantity { get; set; }
    public int UnitId { get; set; }
    public int BrandId { get; set; }

    public Unit? Unit { get; set; }
    public Brand? Brand { get; set; }
    public ICollection<Conversion>? Conversions { get; set; }
    public ICollection<RecipeIngredient>? RecipeIngredients { get; set; }
}