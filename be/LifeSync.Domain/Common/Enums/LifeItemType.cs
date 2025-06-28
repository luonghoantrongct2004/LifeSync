namespace LifeSync.Domain.Common.Enums;

public enum LifeItemType
{
    Todo = 1,
    Goal = 2
}

public static class LifeItemTypeExtensions
{
    public static string ToString(this LifeItemType type)
    {
        return type switch
        {
            LifeItemType.Todo => "todo",
            LifeItemType.Goal => "goal",
            _ => throw new ArgumentException($"Unknown life item type: {type}")
        };
    }

    public static LifeItemType FromString(string type)
    {
        return type.ToLower() switch
        {
            "todo" => LifeItemType.Todo,
            "goal" => LifeItemType.Goal,
            _ => throw new ArgumentException($"Unknown life item type: {type}")
        };
    }
} 