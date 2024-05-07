using System;
using System.Collections.Generic;

namespace task_2_.Models;

public partial class Recipe
{
    public decimal RecipeId { get; set; }

    public string? RecipeName { get; set; }

    public decimal? TimeTakes { get; set; }

    public decimal? Price { get; set; }

    public decimal? TotalCalories { get; set; }

    public string? Description { get; set; }

    public string RepcipePdf { get; set; } = null!;

    public decimal? UserId { get; set; }

    public decimal? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual User? User { get; set; }
}
