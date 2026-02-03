using finance_manager;
using FinanceManager.DataAccess.Context;
using IDataAccess;

namespace FinanceManager.DataAccess.Repositories;

public class CurrencyRepository(SqlContext context) : ICurrencyRepository
{
    private readonly SqlContext _context = context;

    public Currency? GetById(string currencyId)
    {
        return _context.Currencies.FirstOrDefault(c => c.Id == currencyId);
    }

    public Currency? GetByCode(string code)
    {
        return _context.Currencies.FirstOrDefault(c => c.Code == code);
    }

    public List<Currency> GetAll()
    {
        return _context.Currencies.OrderBy(c => c.Code).ToList();
    }

    public bool Add(Currency currency)
    {
        _context.Currencies.Add(currency);
        return true;
    }

    public bool Update(Currency currency)
    {
        _context.Currencies.Update(currency);
        return true;
    }

    public bool Delete(Currency currency)
    {
        _context.Currencies.Remove(currency);
        return true;
    }
}
