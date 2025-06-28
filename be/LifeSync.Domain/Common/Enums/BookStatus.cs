namespace LifeSync.Domain.Common.Enums;

public enum BookStatus
{
    Available = 1,
    Reading = 2,
    Completed = 3,
    Archived = 4
}

public static class BookStatusExtensions
{
    public static string ToString(this BookStatus status)
    {
        return status switch
        {
            BookStatus.Available => "available",
            BookStatus.Reading => "reading",
            BookStatus.Completed => "completed",
            BookStatus.Archived => "archived",
            _ => throw new ArgumentException($"Unknown book status: {status}")
        };
    }

    public static BookStatus FromString(string status)
    {
        return status.ToLower() switch
        {
            "available" => BookStatus.Available,
            "reading" => BookStatus.Reading,
            "completed" => BookStatus.Completed,
            "archived" => BookStatus.Archived,
            _ => throw new ArgumentException($"Unknown book status: {status}")
        };
    }
} 