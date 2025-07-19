using System.ComponentModel.DataAnnotations.Schema;

namespace BetterAuth.Db.Entities;

[Table("Users")]
public partial class User : BaseEntity
{
    private string _email = default!;

    public string Email { 
        get => _email;
        set => _email = value.Trim().ToLowerInvariant();
    }

    public bool EmailVerified { get; set; } = false;
    public string Name { get; set; } = default!;
    public string? Image { get; set; }

    public virtual Account Account { get; set; } = default!;
    public virtual Session Session { get; set; } = default!;
}
