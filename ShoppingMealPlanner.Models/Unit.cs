﻿using System.ComponentModel.DataAnnotations;

namespace ShoppingMealPlanner.Models;

public class Unit
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = String.Empty;

    public ICollection<Conversion>? Conversions { get; set; }
    public ICollection<Ingredient>? Ingredients { get; set; }
    public ICollection<RecipeIngredient>? RecipeIngredients { get; set; }
}