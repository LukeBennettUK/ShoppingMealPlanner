namespace ShoppingMealPlanner.Api.Models;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public int Quantity { get; set; }
    public int UnitId { get; set; }
    public int BrandId { get; set; }
}