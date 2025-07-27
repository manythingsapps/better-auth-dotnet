using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace BetterAuth.Db.EntityConfigurations;

internal class GuidToStringGenerator : ValueGenerator<string>
{
    public override string Next(EntityEntry entry)
    {
        return Guid.NewGuid().ToString();
    }

    public override bool GeneratesTemporaryValues => false;
}

internal class DateTimeUtcGenerator : ValueGenerator<DateTime>
{
    public override DateTime Next(EntityEntry entry)
    {
        return DateTime.UtcNow;
    }
    public override bool GeneratesTemporaryValues => false;
}