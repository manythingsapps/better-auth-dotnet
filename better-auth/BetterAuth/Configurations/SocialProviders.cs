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

public sealed class SocialProvidersOptions
{
    private Dictionary<string, EnabledOption>? _socialProviders;

    public Dictionary<string, EnabledOption>? SocialProviders
    { 
        get => _socialProviders;
        set => _socialProviders = Enum.GetNames(typeof(SocialProvidersList))
            .ToDictionary(provider => provider, provider => value?.GetValueOrDefault(provider) ?? new EnabledOption(false));
    }
}

public sealed record EnabledOption(bool? Enabled);