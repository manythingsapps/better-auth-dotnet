using System.ComponentModel.DataAnnotations.Schema;

namespace BetterAuth.Db.Entities;

/// <summary>
/// Provide additional properties by inheriting.
/// </summary>
[Table("Verifications")]
public partial class Verification<T>
{
    public T Id { get; set; } = default!;
    public string Value { get; set; } = default!;
    public DateTime ExpiresAt { get; set; }
    public string Identifier { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

/// <summary>
/// Base Verification class with string as the ID type.
/// </summary>
public partial class Verification : Verification<string>
{
    
}