namespace LifeSync.Domain.Common.Constants;

public static class TransactionCategories
{
    public static class Income
    {
        public const string Salary = "salary";
        public const string Bonus = "bonus";
        public const string Investment = "investment";
        public const string Freelance = "freelance";
        public const string Other = "other";
    }

    public static class Expense
    {
        public const string Food = "food";
        public const string Transportation = "transportation";
        public const string Shopping = "shopping";
        public const string Entertainment = "entertainment";
        public const string Health = "health";
        public const string Education = "education";
        public const string Housing = "housing";
        public const string Utilities = "utilities";
        public const string Other = "other";
    }

    public static IEnumerable<string> GetAllIncomeCategories()
    {
        return new[]
        {
            Income.Salary,
            Income.Bonus,
            Income.Investment,
            Income.Freelance,
            Income.Other
        };
    }

    public static IEnumerable<string> GetAllExpenseCategories()
    {
        return new[]
        {
            Expense.Food,
            Expense.Transportation,
            Expense.Shopping,
            Expense.Entertainment,
            Expense.Health,
            Expense.Education,
            Expense.Housing,
            Expense.Utilities,
            Expense.Other
        };
    }
} 