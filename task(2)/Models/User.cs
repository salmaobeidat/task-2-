using System;
using System.Collections.Generic;

namespace task_2_.Models;

public partial class User
{
    public decimal UserId { get; set; }

    public string? UserName { get; set; }

    public string? Gender { get; set; }

    public string? Nationality { get; set; }

    public string? Specialization { get; set; }

    public decimal? RoleId { get; set; }

    public virtual Credential? Credential { get; set; }

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

    public virtual Role? Role { get; set; }
}
