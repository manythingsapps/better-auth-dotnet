namespace BetterAuth.Helpers;

internal static class StringHelpers
{
    public static string GenerateId(int? size = 32)
    {
        // Gererate a random string of the specified size
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        var id = new char[size ?? 32];
        for (int i = 0; i < (size ?? 32); i++)
        {
            id[i] = chars[random.Next(chars.Length)];
        }
        return new string(id);
    }
}
