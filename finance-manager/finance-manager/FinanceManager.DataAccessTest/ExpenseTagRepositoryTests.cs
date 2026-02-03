using finance_manager;
using FinanceManager.DataAccess.Context;
using FinanceManager.DataAccess.Repositories;
using Shared;

namespace UserRepositoryTest;

[TestClass]
public class ExpenseTagRepositoryTests
{
    private SqlContext _context = null!;
    private ExpenseTagRepository _repo = null!;
    private User _user = null!;
    private ExpenseTag _tag1 = null!;
    private ExpenseTag _tag2 = null!;

    [TestInitialize]
    public void Setup()
    {
        _context = new SqlContextFactory().CreateMemoryContext();
        _repo = new ExpenseTagRepository(_context);
        _user = new User("Test", "User", "test@test.com", "Pass123!", new DateTime(1990, 1, 1));
        _context.Users.Add(_user);
        _context.SaveChanges();
        _tag1 = new ExpenseTag(_user, "Comida", "Gastos en comida", new Color("#FF5733"), "icon1");
        _tag2 = new ExpenseTag(_user, "Transporte", "Gastos en transporte", new Color("#33FF57"), "icon2");
    }

    [TestCleanup]
    public void CleanUp() => _context.Dispose();

    [TestMethod]
    public void GetExpenseTagById_WithExistingId_ShouldReturnTag()
    {
        _context.ExpenseTags.Add(_tag1);
        _context.SaveChanges();

        ExpenseTag? found = _repo.GetExpenseTagById(_tag1.Id);

        Assert.IsNotNull(found);
        Assert.AreEqual(_tag1.Id, found.Id);
        Assert.AreEqual("Comida", found.Name);
    }

    [TestMethod]
    public void GetExpenseTagById_WithNonExistingId_ShouldReturnNull()
    {
        ExpenseTag? found = _repo.GetExpenseTagById(Guid.NewGuid().ToString());
        Assert.IsNull(found);
    }

    [TestMethod]
    public void GetExpenseTags_WithNoTags_ShouldReturnEmptyList()
    {
        List<ExpenseTag> list = _repo.GetExpenseTags();
        Assert.IsNotNull(list);
        Assert.AreEqual(0, list.Count);
    }

    [TestMethod]
    public void GetExpenseTags_WithTags_ShouldReturnAllTags()
    {
        _context.ExpenseTags.Add(_tag1);
        _context.ExpenseTags.Add(_tag2);
        _context.SaveChanges();

        List<ExpenseTag> list = _repo.GetExpenseTags();

        Assert.AreEqual(2, list.Count);
    }

    [TestMethod]
    public void AddExpenseTag_WithValidTag_ShouldReturnTrue()
    {
        bool result = _repo.AddExpenseTag(_tag1);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void UpdateExpenseTag_WithValidTag_ShouldReturnTrue()
    {
        _context.ExpenseTags.Add(_tag1);
        _context.SaveChanges();
        _tag1.Name = "Comida actualizada";

        bool result = _repo.UpdateExpenseTag(_tag1);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void DeleteExpenseTag_WithExistingTag_ShouldReturnTrue()
    {
        _context.ExpenseTags.Add(_tag1);
        _context.SaveChanges();

        bool result = _repo.DeleteExpenseTag(_tag1);

        Assert.IsTrue(result);
    }
}
