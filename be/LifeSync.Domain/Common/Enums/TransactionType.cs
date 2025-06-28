namespace LifeSync.Domain.Common.Enums;

public enum TransactionType
{
    Income = 1,
    Expense = 2
}

public static class TransactionTypeExtensions
{
    public static string ToString(this TransactionType type)
    {
        return type switch
        {
            TransactionType.Income => "income",
            TransactionType.Expense => "expense",
            _ => throw new ArgumentException($"Unknown transaction type: {type}")
        };
    }

    public static TransactionType FromString(string type)
    {
        return type.ToLower() switch
        {
            "income" => TransactionType.Income,
            "expense" => TransactionType.Expense,
            _ => throw new ArgumentException($"Unknown transaction type: {type}")
        };
    }
} 