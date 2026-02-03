using finance_manager;
using FinanceManager.DataAccess.Context;
using FinanceManager.DataAccess.Repositories;

namespace UserRepositoryTest;

[TestClass]
public class AccountRepositoryTests
{
    private SqlContext _context = null!;
    private AccountRepository _repo = null!;
    private User _user = null!;
    private Currency _currencyUsd = null!;
    private Currency _currencyEur = null!;
    private Account _account1 = null!;
    private Account _account2 = null!;

    [TestInitialize]
    public void Setup()
    {
        _context = new SqlContextFactory().CreateMemoryContext();
        _repo = new AccountRepository(_context);
        _user = new User("Test", "User", "test@test.com", "Pass123!", new DateTime(1990, 1, 1));
        _currencyUsd = new Currency("USD", "Dólar estadounidense", "$");
        _currencyEur = new Currency("EUR", "Euro", "€");
        _context.Users.Add(_user);
        _context.Currencies.Add(_currencyUsd);
        _context.Currencies.Add(_currencyEur);
        _context.SaveChanges();
        _account1 = new Account("Cuenta principal", _currencyUsd, 1000m, "Principal");
        _account2 = new Account("Ahorros", _currencyEur, 500m, "Cuenta de ahorros");
    }

    [TestCleanup]
    public void CleanUp() => _context.Dispose();

    [TestMethod]
    public void GetById_WithExistingId_ShouldReturnAccount()
    {
        _repo.Add(_account1, _user.Id);
        _context.SaveChanges();

        Account? found = _repo.GetById(_account1.Id);

        Assert.IsNotNull(found);
        Assert.AreEqual(_account1.Id, found.Id);
        Assert.AreEqual("Cuenta principal", found.Name);
    }

    [TestMethod]
    public void GetById_WithNonExistingId_ShouldReturnNull()
    {
        Account? found = _repo.GetById(Guid.NewGuid().ToString());
        Assert.IsNull(found);
    }

    [TestMethod]
    public void GetByUserId_WithAccounts_ShouldReturnUserAccounts()
    {
        _repo.Add(_account1, _user.Id);
        _repo.Add(_account2, _user.Id);
        _context.SaveChanges();

        List<Account> list = _repo.GetByUserId(_user.Id);

        Assert.AreEqual(2, list.Count);
    }

    [TestMethod]
    public void GetByUserId_WithNoAccounts_ShouldReturnEmptyList()
    {
        List<Account> list = _repo.GetByUserId(_user.Id);
        Assert.IsNotNull(list);
        Assert.AreEqual(0, list.Count);
    }

    [TestMethod]
    public void GetAll_WithAccounts_ShouldReturnAllAccounts()
    {
        _repo.Add(_account1, _user.Id);
        _context.SaveChanges();

        List<Account> list = _repo.GetAll();

        Assert.AreEqual(1, list.Count);
    }

    [TestMethod]
    public void Add_WithValidAccountAndUserId_ShouldReturnTrue()
    {
        bool result = _repo.Add(_account1, _user.Id);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Update_WithValidAccount_ShouldReturnTrue()
    {
        _repo.Add(_account1, _user.Id);
        _context.SaveChanges();
        _account1.Name = "Cuenta renombrada";

        bool result = _repo.Update(_account1);

        Assert.IsTrue(result);
    }
}
