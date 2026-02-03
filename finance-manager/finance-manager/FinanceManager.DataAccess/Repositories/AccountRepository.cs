using finance_manager;
using FinanceManager.DataAccess.Context;
using IDataAccess;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.DataAccess.Repositories;

public class AccountRepository(SqlContext context) : IAccountRepository
{
    private readonly SqlContext _context = context;

    public Account? GetById(string accountId)
    {
        return _context.Accounts.FirstOrDefault(a => a.Id == accountId);
    }

    public List<Account> GetByUserId(string userId)
    {
        return _context.Accounts
            .Where(a => EF.Property<string>(a, "UserId") == userId)
            .ToList();
    }

    public List<Account> GetAll()
    {
        return _context.Accounts.ToList();
    }

    public bool Add(Account account, string userId)
    {
        _context.Accounts.Add(account);
        _context.Entry(account).Property("UserId").CurrentValue = userId;
        return true;
    }

    public bool Update(Account account)
    {
        _context.Accounts.Update(account);
        return true;
    }
}
