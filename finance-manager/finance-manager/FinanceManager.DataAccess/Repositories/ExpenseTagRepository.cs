using finance_manager;
using FinanceManager.DataAccess.Context;
using IDataAccess;

namespace FinanceManager.DataAccess.Repositories;

public class ExpenseTagRepository(SqlContext context) : IExpenseTagRepository
{
    private readonly SqlContext _context = context;

    public bool AddExpenseTag(ExpenseTag expenseTag)
    {
        _context.ExpenseTags.Add(expenseTag);
        return true;
    }

    public bool UpdateExpenseTag(ExpenseTag expenseTag)
    {
        _context.ExpenseTags.Update(expenseTag);
        return true;
    }

    public bool DeleteExpenseTag(ExpenseTag expenseTag)
    {
        _context.ExpenseTags.Remove(expenseTag);
        return true;
    }

    public ExpenseTag? GetExpenseTagById(string expenseTagId)
    {
        return _context.ExpenseTags.FirstOrDefault(t => t.Id == expenseTagId);
    }

    public List<ExpenseTag> GetExpenseTags()
    {
        return _context.ExpenseTags.ToList();
    }
}
