using finance_manager;
using FinanceManager.DataAccess.Context;
using IDataAccess;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.DataAccess.Repositories;

public class ExpenseRepository(SqlContext context) : IExpenseRepository
{
    private readonly SqlContext _context = context;

    public Expense? GetById(string expenseId)
    {
        return _context.Expenses
            .Include(e => e.Tag)
            .FirstOrDefault(e => e.Id == expenseId);
    }

    public List<Expense> GetByPurchaseId(string purchaseId)
    {
        return _context.Expenses
            .Where(e => EF.Property<string>(e, "PurchaseId") == purchaseId)
            .Include(e => e.Tag)
            .ToList();
    }

    public List<Expense> GetByTagId(string tagId)
    {
        return _context.Expenses
            .Where(e => EF.Property<string>(e, "TagId") == tagId)
            .Include(e => e.Tag)
            .ToList();
    }

    public bool Add(Expense expense, string purchaseId)
    {
        _context.Expenses.Add(expense);
        _context.Entry(expense).Property("PurchaseId").CurrentValue = purchaseId;
        return true;
    }

    public bool Update(Expense expense)
    {
        _context.Expenses.Update(expense);
        return true;
    }

    public bool Delete(Expense expense)
    {
        _context.Expenses.Remove(expense);
        return true;
    }
}
