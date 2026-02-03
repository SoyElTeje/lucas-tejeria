using finance_manager;
using FinanceManager.DataAccess.Context;
using FinanceManager.DataAccess.Repositories;

namespace UserRepositoryTest;

[TestClass]
public class ExpenseRepositoryTests
{
    private SqlContext _context = null!;
    private ExpenseRepository _repo = null!;
    private User _user = null!;
    private Color _color = null!;
    private ExpenseTag _tag = null!;
    private Currency _currency = null!;
    private Account _account = null!;
    private Purchase _purchase = null!;
    private Expense _expense1 = null!;
    private Expense _expense2 = null!;

    [TestInitialize]
    public void Setup()
    {
        _context = new SqlContextFactory().CreateMemoryContext();
        _repo = new ExpenseRepository(_context);
        _user = new User("Test", "User", "test@test.com", "Pass123!", new DateTime(1990, 1, 1));
        _currency = new Currency("USD", "Dólar", "$");
        _color = new Color("Rojo", "#FF0000");
        _context.Users.Add(_user);
        _context.Currencies.Add(_currency);
        _context.Colors.Add(_color);
        _context.SaveChanges();
        _tag = new ExpenseTag(_user, "Comida", "Gastos comida", _color, "icon");
        _context.ExpenseTags.Add(_tag);
        _context.SaveChanges();
        _account = new Account("Cuenta", _currency, 0m, "");
        _context.Accounts.Add(_account);
        _context.Entry(_account).Property("UserId").CurrentValue = _user.Id;
        _context.SaveChanges();
        _purchase = new Purchase(new DateTime(2025, 1, 15), "Compra");
        _context.Purchases.Add(_purchase);
        _context.Entry(_purchase).Property("AccountId").CurrentValue = _account.Id;
        _context.SaveChanges();
        _expense1 = new Expense("Pan", 10.50m, _tag);
        _expense2 = new Expense("Leche", 5.25m, _tag);
    }

    [TestCleanup]
    public void CleanUp() => _context.Dispose();

    [TestMethod]
    public void GetById_WithExistingId_ShouldReturnExpense()
    {
        _repo.Add(_expense1, _purchase.Id);
        _context.SaveChanges();

        Expense? found = _repo.GetById(_expense1.Id);

        Assert.IsNotNull(found);
        Assert.AreEqual(_expense1.Id, found.Id);
        Assert.AreEqual("Pan", found.Name);
        Assert.AreEqual(10.50m, found.Amount);
    }

    [TestMethod]
    public void GetById_WithNonExistingId_ShouldReturnNull()
    {
        Expense? found = _repo.GetById(Guid.NewGuid().ToString());
        Assert.IsNull(found);
    }

    [TestMethod]
    public void GetByPurchaseId_WithExpenses_ShouldReturnPurchaseExpenses()
    {
        _repo.Add(_expense1, _purchase.Id);
        _repo.Add(_expense2, _purchase.Id);
        _context.SaveChanges();

        List<Expense> list = _repo.GetByPurchaseId(_purchase.Id);

        Assert.AreEqual(2, list.Count);
    }

    [TestMethod]
    public void GetByTagId_WithExpenses_ShouldReturnTagExpenses()
    {
        _repo.Add(_expense1, _purchase.Id);
        _repo.Add(_expense2, _purchase.Id);
        _context.SaveChanges();

        List<Expense> list = _repo.GetByTagId(_tag.Id);

        Assert.AreEqual(2, list.Count);
    }

    [TestMethod]
    public void Add_WithValidExpenseAndPurchaseId_ShouldReturnTrue()
    {
        bool result = _repo.Add(_expense1, _purchase.Id);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Update_WithValidExpense_ShouldReturnTrue()
    {
        _repo.Add(_expense1, _purchase.Id);
        _context.SaveChanges();
        _expense1.UpdateAmount(15m);

        bool result = _repo.Update(_expense1);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Delete_WithExistingExpense_ShouldReturnTrue()
    {
        _repo.Add(_expense1, _purchase.Id);
        _context.SaveChanges();

        bool result = _repo.Delete(_expense1);

        Assert.IsTrue(result);
    }
}
