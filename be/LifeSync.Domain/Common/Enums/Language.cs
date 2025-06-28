namespace LifeSync.Domain.Common.Enums;

public enum Language
{
    Vietnamese = 1,
    English = 2,
    Chinese = 3,
    Japanese = 4,
    Korean = 5
}

public static class LanguageExtensions
{
    public static string ToString(this Language language)
    {
        return language switch
        {
            Language.Vietnamese => "vi",
            Language.English => "en",
            Language.Chinese => "zh",
            Language.Japanese => "ja",
            Language.Korean => "ko",
            _ => throw new ArgumentException($"Unknown language: {language}")
        };
    }

    public static Language FromString(string language)
    {
        return language.ToLower() switch
        {
            "vi" => Language.Vietnamese,
            "en" => Language.English,
            "zh" => Language.Chinese,
            "ja" => Language.Japanese,
            "ko" => Language.Korean,
            _ => throw new ArgumentException($"Unknown language: {language}")
        };
    }
} 