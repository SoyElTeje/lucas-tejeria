using finance_manager;
using FinanceManager.DataAccess.Context;
using IDataAccess;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.DataAccess.Repositories;

public class PurchaseRepository(SqlContext context) : IPurchaseRepository
{
    private readonly SqlContext _context = context;

    public Purchase? GetById(string purchaseId)
    {
        return _context.Purchases
            .Include(p => p.Expenses)
            .ThenInclude(e => e.Tag)
            .FirstOrDefault(p => p.Id == purchaseId);
    }

    public List<Purchase> GetByAccountId(string accountId)
    {
        return _context.Purchases
            .Where(p => EF.Property<string>(p, "AccountId") == accountId)
            .Include(p => p.Expenses)
            .ThenInclude(e => e.Tag)
            .OrderByDescending(p => p.Date)
            .ToList();
    }

    public bool Add(Purchase purchase, string accountId)
    {
        _context.Purchases.Add(purchase);
        _context.Entry(purchase).Property("AccountId").CurrentValue = accountId;
        return true;
    }

    public bool Update(Purchase purchase)
    {
        _context.Purchases.Update(purchase);
        return true;
    }

    public bool Delete(Purchase purchase)
    {
        _context.Purchases.Remove(purchase);
        return true;
    }
}
