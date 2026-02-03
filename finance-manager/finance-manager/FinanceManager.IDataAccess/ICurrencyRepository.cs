using finance_manager;

namespace IDataAccess;

public interface ICurrencyRepository
{
    Currency? GetById(string currencyId);
    Currency? GetByCode(string code);
    List<Currency> GetAll();
    bool Add(Currency currency);
    bool Update(Currency currency);
    bool Delete(Currency currency);
}
