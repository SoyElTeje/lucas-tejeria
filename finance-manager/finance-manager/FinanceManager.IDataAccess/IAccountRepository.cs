using finance_manager;

namespace IDataAccess;

public interface IAccountRepository
{
    Account? GetById(string accountId);
    List<Account> GetByUserId(string userId);
    List<Account> GetAll();
    bool Add(Account account, string userId);
    bool Update(Account account);
}
