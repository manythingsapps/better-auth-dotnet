using System.ComponentModel.DataAnnotations.Schema;

namespace BetterAuth.Db.Entities;

/// <summary>
/// Provide additional properties by inheriting.
/// </summary>
[Table("Users")]
public partial class User<T>
{
    private string _email = default!;

    public string Email { 
        get => _email;
        set => _email = value.Trim().ToLowerInvariant();
    }

    public T Id { get; set; } = default!;
    public bool EmailVerified { get; set; } = false;
    public string Name { get; set; } = default!;
    public string? Image { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public virtual Account<T> Account { get; set; } = default!;
    public virtual Session<T> Session { get; set; } = default!;
}

/// <summary>
/// Base User class with string as the ID type.
/// </summary>
public partial class User : User<string>
{
    public override Account<string> Account { get; set; } = default!;
    public override Session<string> Session { get; set; } = default!;
}