namespace ShoppingMealPlanner.Api.Models;

public class RecipeIngredient
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int IngredientId { get; set; }
    public int RecipeId { get; set; }
}
