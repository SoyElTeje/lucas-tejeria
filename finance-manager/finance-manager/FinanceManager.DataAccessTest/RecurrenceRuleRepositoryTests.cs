using finance_manager;
using FinanceManager.DataAccess.Context;
using FinanceManager.DataAccess.Repositories;

namespace UserRepositoryTest;

[TestClass]
public class RecurrenceRuleRepositoryTests
{
    private SqlContext _context = null!;
    private RecurrenceRuleRepository _repo = null!;
    private User _user1 = null!;
    private User _user2 = null!;
    private EveryNDaysRule _rule1 = null!;
    private EveryNDaysRule _rule2 = null!;

    [TestInitialize]
    public void Setup()
    {
        _context = new SqlContextFactory().CreateMemoryContext();
        _repo = new RecurrenceRuleRepository(_context);
        _user1 = new User("Test1", "User", "test1@test.com", "Pass123!", new DateTime(1990, 1, 1));
        _user2 = new User("Test2", "User", "test2@test.com", "Pass123!", new DateTime(1992, 5, 5));
        _context.Users.Add(_user1);
        _context.Users.Add(_user2);
        _context.SaveChanges();
        _rule1 = new EveryNDaysRule(_user1, 7, "Semanal");
        _rule2 = new EveryNDaysRule(_user1, 30, "Mensual");
    }

    [TestCleanup]
    public void CleanUp() => _context.Dispose();

    [TestMethod]
    public void GetById_WithExistingId_ShouldReturnRule()
    {
        _context.RecurrenceRules.Add(_rule1);
        _context.SaveChanges();

        RecurrenceRuleBase? found = _repo.GetById(_rule1.Id);

        Assert.IsNotNull(found);
        Assert.AreEqual(_rule1.Id, found.Id);
        Assert.AreEqual("Semanal", found.RuleName);
        Assert.IsTrue(found is EveryNDaysRule);
        Assert.AreEqual(7, ((EveryNDaysRule)found).NumberOfDays);
    }

    [TestMethod]
    public void GetById_WithNonExistingId_ShouldReturnNull()
    {
        RecurrenceRuleBase? found = _repo.GetById(Guid.NewGuid().ToString());
        Assert.IsNull(found);
    }

    [TestMethod]
    public void GetByCreatorId_WithRules_ShouldReturnCreatorRules()
    {
        _context.RecurrenceRules.Add(_rule1);
        _context.RecurrenceRules.Add(_rule2);
        _context.SaveChanges();

        List<RecurrenceRuleBase> list = _repo.GetByCreatorId(_user1.Id);

        Assert.AreEqual(2, list.Count);
    }

    [TestMethod]
    public void GetByCreatorId_WithNoRules_ShouldReturnEmptyList()
    {
        List<RecurrenceRuleBase> list = _repo.GetByCreatorId(_user1.Id);
        Assert.IsNotNull(list);
        Assert.AreEqual(0, list.Count);
    }

    [TestMethod]
    public void Add_WithValidRule_ShouldReturnTrue()
    {
        bool result = _repo.Add(_rule1);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Update_WithValidRule_ShouldReturnTrue()
    {
        _context.RecurrenceRules.Add(_rule1);
        _context.SaveChanges();
        _rule1.RuleName = "Semanal actualizado";

        bool result = _repo.Update(_rule1);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Delete_WithExistingRule_ShouldReturnTrue()
    {
        _context.RecurrenceRules.Add(_rule1);
        _context.SaveChanges();

        bool result = _repo.Delete(_rule1);

        Assert.IsTrue(result);
    }
}
