using finance_manager;

namespace IDataAccess;

public interface IExpenseRepository
{
    Expense? GetById(string expenseId);
    List<Expense> GetByPurchaseId(string purchaseId);
    List<Expense> GetByTagId(string tagId);
    bool Add(Expense expense, string purchaseId);
    bool Update(Expense expense);
    bool Delete(Expense expense);
}
