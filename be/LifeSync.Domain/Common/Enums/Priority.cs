namespace LifeSync.Domain.Common.Enums;

public enum Priority
{
    Low = 1,
    Medium = 2,
    High = 3,
    Critical = 4
}

public static class PriorityExtensions
{
    public static string ToString(this Priority priority)
    {
        return priority switch
        {
            Priority.Low => "low",
            Priority.Medium => "medium",
            Priority.High => "high",
            Priority.Critical => "critical",
            _ => throw new ArgumentException($"Unknown priority: {priority}")
        };
    }

    public static Priority FromString(string priority)
    {
        return priority.ToLower() switch
        {
            "low" => Priority.Low,
            "medium" => Priority.Medium,
            "high" => Priority.High,
            "critical" => Priority.Critical,
            _ => throw new ArgumentException($"Unknown priority: {priority}")
        };
    }
} 