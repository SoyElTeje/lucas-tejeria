using finance_manager;
using FinanceManager.DataAccess.Context;
using FinanceManager.DataAccess.Repositories;

namespace UserRepositoryTest;

[TestClass]
public class PurchaseRepositoryTests
{
    private SqlContext _context = null!;
    private PurchaseRepository _repo = null!;
    private User _user = null!;
    private Currency _currency = null!;
    private Account _account = null!;
    private Purchase _purchase1 = null!;
    private Purchase _purchase2 = null!;

    [TestInitialize]
    public void Setup()
    {
        _context = new SqlContextFactory().CreateMemoryContext();
        _repo = new PurchaseRepository(_context);
        _user = new User("Test", "User", "test@test.com", "Pass123!", new DateTime(1990, 1, 1));
        _currency = new Currency("USD", "Dólar", "$");
        _account = new Account("Cuenta", _currency, 0m, "");
        _context.Currencies.Add(_currency);
        _context.Users.Add(_user);
        _context.SaveChanges();
        _context.Accounts.Add(_account);
        _context.Entry(_account).Property("UserId").CurrentValue = _user.Id;
        _context.SaveChanges();
        _purchase1 = new Purchase(new DateTime(2025, 1, 15), "Supermercado");
        _purchase2 = new Purchase(new DateTime(2025, 1, 20), "Farmacia");
    }

    [TestCleanup]
    public void CleanUp() => _context.Dispose();

    [TestMethod]
    public void GetById_WithExistingId_ShouldReturnPurchase()
    {
        _repo.Add(_purchase1, _account.Id);
        _context.SaveChanges();

        Purchase? found = _repo.GetById(_purchase1.Id);

        Assert.IsNotNull(found);
        Assert.AreEqual(_purchase1.Id, found.Id);
        Assert.AreEqual("Supermercado", found.Notes);
    }

    [TestMethod]
    public void GetById_WithNonExistingId_ShouldReturnNull()
    {
        Purchase? found = _repo.GetById(Guid.NewGuid().ToString());
        Assert.IsNull(found);
    }

    [TestMethod]
    public void GetByAccountId_WithPurchases_ShouldReturnAccountPurchases()
    {
        _repo.Add(_purchase1, _account.Id);
        _repo.Add(_purchase2, _account.Id);
        _context.SaveChanges();

        List<Purchase> list = _repo.GetByAccountId(_account.Id);

        Assert.AreEqual(2, list.Count);
    }

    [TestMethod]
    public void GetByAccountId_WithNoPurchases_ShouldReturnEmptyList()
    {
        List<Purchase> list = _repo.GetByAccountId(_account.Id);
        Assert.IsNotNull(list);
        Assert.AreEqual(0, list.Count);
    }

    [TestMethod]
    public void Add_WithValidPurchaseAndAccountId_ShouldReturnTrue()
    {
        bool result = _repo.Add(_purchase1, _account.Id);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Update_WithValidPurchase_ShouldReturnTrue()
    {
        _repo.Add(_purchase1, _account.Id);
        _context.SaveChanges();
        _purchase1.Notes = "Super actualizado";

        bool result = _repo.Update(_purchase1);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Delete_WithExistingPurchase_ShouldReturnTrue()
    {
        _repo.Add(_purchase1, _account.Id);
        _context.SaveChanges();

        bool result = _repo.Delete(_purchase1);

        Assert.IsTrue(result);
    }
}
