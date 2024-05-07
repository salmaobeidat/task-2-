using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace task_2_.Models;

public partial class Credential
{
    public decimal CredentialId { get; set; }
    [Required]
    public string Email { get; set; } = null!;
    [Required]

    public string Password { get; set; } = null!;

    public decimal? UserId { get; set; }

    public virtual User? User { get; set; }
}
