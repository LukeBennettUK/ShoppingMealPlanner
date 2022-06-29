﻿namespace ShoppingMealPlanner.Models;

public class RecipeIngredient
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int UnitId { get; set; }
    public int IngredientId { get; set; }
    public int RecipeId { get; set; }
    
    public Unit? Unit { get; set; }
    public Ingredient? Ingredient { get; set; }
    public Recipe? Recipe { get; set; }
}
