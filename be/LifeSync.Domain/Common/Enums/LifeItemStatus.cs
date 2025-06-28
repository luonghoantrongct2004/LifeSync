namespace LifeSync.Domain.Common.Enums;

public enum LifeItemStatus
{
    Pending = 1,
    InProgress = 2,
    Completed = 3,
    Cancelled = 4
}

public static class LifeItemStatusExtensions
{
    public static string ToString(this LifeItemStatus status)
    {
        return status switch
        {
            LifeItemStatus.Pending => "pending",
            LifeItemStatus.InProgress => "in_progress",
            LifeItemStatus.Completed => "completed",
            LifeItemStatus.Cancelled => "cancelled",
            _ => throw new ArgumentException($"Unknown life item status: {status}")
        };
    }

    public static LifeItemStatus FromString(string status)
    {
        return status.ToLower() switch
        {
            "pending" => LifeItemStatus.Pending,
            "in_progress" => LifeItemStatus.InProgress,
            "completed" => LifeItemStatus.Completed,
            "cancelled" => LifeItemStatus.Cancelled,
            _ => throw new ArgumentException($"Unknown life item status: {status}")
        };
    }
} 