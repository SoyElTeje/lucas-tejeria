using finance_manager;
using FinanceManager.DataAccess.Context;
using FinanceManager.DataAccess.Repositories;

namespace UserRepositoryTest;

[TestClass]
public class ScheduledIncomeRepositoryTests
{
    private SqlContext _context = null!;
    private ScheduledIncomeRepository _repo = null!;
    private User _user = null!;
    private EveryNDaysRule _rule = null!;
    private ScheduledIncome _scheduled1 = null!;
    private ScheduledIncome _scheduled2 = null!;

    [TestInitialize]
    public void Setup()
    {
        _context = new SqlContextFactory().CreateMemoryContext();
        _repo = new ScheduledIncomeRepository(_context);
        _user = new User("Test", "User", "test@test.com", "Pass123!", new DateTime(1990, 1, 1));
        _context.Users.Add(_user);
        _context.SaveChanges();
        _rule = new EveryNDaysRule(_user, 30, "Mensual");
        _context.RecurrenceRules.Add(_rule);
        _context.SaveChanges();
        _scheduled1 = new ScheduledIncome(new DateTime(2025, 1, 1), new DateTime(2025, 12, 31), _rule);
        _scheduled2 = new ScheduledIncome(new DateTime(2025, 6, 1), new DateTime(2025, 6, 30), _rule);
    }

    [TestCleanup]
    public void CleanUp() => _context.Dispose();

    [TestMethod]
    public void GetById_WithExistingId_ShouldReturnScheduledIncome()
    {
        _context.ScheduledIncomes.Add(_scheduled1);
        _context.SaveChanges();

        ScheduledIncome? found = _repo.GetById(_scheduled1.Id);

        Assert.IsNotNull(found);
        Assert.AreEqual(_scheduled1.Id, found.Id);
        Assert.AreEqual(new DateTime(2025, 1, 1), found.StartDate);
        Assert.AreEqual(new DateTime(2025, 12, 31), found.EndDate);
    }

    [TestMethod]
    public void GetById_WithNonExistingId_ShouldReturnNull()
    {
        ScheduledIncome? found = _repo.GetById(Guid.NewGuid().ToString());
        Assert.IsNull(found);
    }

    [TestMethod]
    public void GetAll_WithScheduledIncomes_ShouldReturnAll()
    {
        _context.ScheduledIncomes.Add(_scheduled1);
        _context.ScheduledIncomes.Add(_scheduled2);
        _context.SaveChanges();

        List<ScheduledIncome> list = _repo.GetAll();

        Assert.AreEqual(2, list.Count);
    }

    [TestMethod]
    public void GetAll_WithNoScheduledIncomes_ShouldReturnEmptyList()
    {
        List<ScheduledIncome> list = _repo.GetAll();
        Assert.IsNotNull(list);
        Assert.AreEqual(0, list.Count);
    }

    [TestMethod]
    public void Add_WithValidScheduledIncome_ShouldReturnTrue()
    {
        bool result = _repo.Add(_scheduled1);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Update_WithValidScheduledIncome_ShouldReturnTrue()
    {
        _context.ScheduledIncomes.Add(_scheduled1);
        _context.SaveChanges();
        _scheduled1.EndDate = new DateTime(2025, 6, 30);

        bool result = _repo.Update(_scheduled1);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Delete_WithExistingScheduledIncome_ShouldReturnTrue()
    {
        _context.ScheduledIncomes.Add(_scheduled1);
        _context.SaveChanges();

        bool result = _repo.Delete(_scheduled1);

        Assert.IsTrue(result);
    }
}
