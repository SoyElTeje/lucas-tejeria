using finance_manager;

namespace IDataAccess;

public interface IPurchaseRepository
{
    Purchase? GetById(string purchaseId);
    List<Purchase> GetByAccountId(string accountId);
    bool Add(Purchase purchase, string accountId);
    bool Update(Purchase purchase);
    bool Delete(Purchase purchase);
}
