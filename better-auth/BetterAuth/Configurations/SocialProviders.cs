namespace BetterAuth.Configurations;

internal enum SocialProvidersList
{
    apple,
    discord,
    facebook,
    github,
    microsoft,
    google,
    huggingface,
    slack,
    spotify,
    twitch,
    twitter,
    dropbox,
    kick,
    linear,
    linkedin,
    gitlab,
    tiktok,
    reddit,
    roblox,
    vk,
    zoom,
    notion,
}

internal sealed class SocialProvidersOptions
{
    private Dictionary<string, bool>? _socialProviders;

    public Dictionary<string, bool>? SocialProviders
    { 
        get => _socialProviders;
        set => _socialProviders = Enum.GetNames(typeof(SocialProvidersList))
            .ToDictionary(provider => provider, provider => value?.GetValueOrDefault(provider) ?? false);
    }
}