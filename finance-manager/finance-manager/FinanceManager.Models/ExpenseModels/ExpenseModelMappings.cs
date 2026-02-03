using finance_manager;

namespace FinanceManager.Models.ExpenseModels;

public static class ExpenseModelMappings
{
    /// <summary>
    /// Requiere la entidad ExpenseTag resuelta.
    /// </summary>
    public static Expense ToEntity(this CreateExpenseRequest request, ExpenseTag tag)
    {
        return new Expense(request.Name, request.Amount, tag);
    }

    public static RetrieveExpenseResponse ToResponse(this Expense expense)
    {
        return new RetrieveExpenseResponse
        {
            Id = expense.Id,
            Name = expense.Name,
            Amount = expense.Amount,
            TagId = expense.Tag.Id
        };
    }
}
