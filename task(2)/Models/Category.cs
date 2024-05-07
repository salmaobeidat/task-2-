using System;
using System.Collections.Generic;

namespace task_2_.Models;

public partial class Category
{
    public decimal CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public decimal? UserId { get; set; }

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
