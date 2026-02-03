using finance_manager;
using FinanceManager.DataAccess.Context;
using FinanceManager.DataAccess.Repositories;

namespace UserRepositoryTest;

[TestClass]
public class IncomeRepositoryTests
{
    private SqlContext _context = null!;
    private IncomeRepository _repo = null!;
    private Currency _currencyUsd = null!;
    private Currency _currencyEur = null!;
    private Income _income1 = null!;
    private Income _income2 = null!;

    [TestInitialize]
    public void Setup()
    {
        _context = new SqlContextFactory().CreateMemoryContext();
        _repo = new IncomeRepository(_context);
        _currencyUsd = new Currency("USD", "Dólar estadounidense", "$");
        _currencyEur = new Currency("EUR", "Euro", "€");
        _context.Currencies.Add(_currencyUsd);
        _context.Currencies.Add(_currencyEur);
        _context.SaveChanges();
        _income1 = new Income(1000m, _currencyUsd, new DateTime(2025, 1, 10), "Salario enero");
        _income2 = new Income(500m, _currencyEur, new DateTime(2025, 1, 15), "Bonus");
    }

    [TestCleanup]
    public void CleanUp() => _context.Dispose();

    [TestMethod]
    public void GetById_WithExistingId_ShouldReturnIncome()
    {
        _context.Incomes.Add(_income1);
        _context.SaveChanges();

        Income? found = _repo.GetById(_income1.Id);

        Assert.IsNotNull(found);
        Assert.AreEqual(_income1.Id, found.Id);
        Assert.AreEqual(1000m, found.Amount);
        Assert.AreEqual("Salario enero", found.Description);
    }

    [TestMethod]
    public void GetById_WithNonExistingId_ShouldReturnNull()
    {
        Income? found = _repo.GetById(Guid.NewGuid().ToString());
        Assert.IsNull(found);
    }

    [TestMethod]
    public void GetAll_WithIncomes_ShouldReturnAllIncomes()
    {
        _context.Incomes.Add(_income1);
        _context.Incomes.Add(_income2);
        _context.SaveChanges();

        List<Income> list = _repo.GetAll();

        Assert.AreEqual(2, list.Count);
    }

    [TestMethod]
    public void GetAll_WithNoIncomes_ShouldReturnEmptyList()
    {
        List<Income> list = _repo.GetAll();
        Assert.IsNotNull(list);
        Assert.AreEqual(0, list.Count);
    }

    [TestMethod]
    public void GetByScheduledIncomeId_WithIncomes_ShouldReturnScheduledIncomes()
    {
        var user = new User("Test", "User", "sched@test.com", "Pass123!", new DateTime(1990, 1, 1));
        _context.Users.Add(user);
        _context.SaveChanges();
        var rule = new EveryNDaysRule(user, 30, "Mensual");
        _context.RecurrenceRules.Add(rule);
        _context.SaveChanges();
        var scheduled = new ScheduledIncome(new DateTime(2025, 1, 1), new DateTime(2025, 12, 31), rule);
        _context.ScheduledIncomes.Add(scheduled);
        _context.SaveChanges();
        var incomeLinked = new Income(800m, _currencyUsd, new DateTime(2025, 1, 15), "Ingreso programado", scheduled);
        _context.Incomes.Add(incomeLinked);
        _context.SaveChanges();

        List<Income> list = _repo.GetByScheduledIncomeId(scheduled.Id);

        Assert.AreEqual(1, list.Count);
        Assert.AreEqual(scheduled.Id, list[0].ScheduledIncome?.Id);
    }

    [TestMethod]
    public void Add_WithValidIncome_ShouldReturnTrue()
    {
        bool result = _repo.Add(_income1);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Update_WithValidIncome_ShouldReturnTrue()
    {
        _context.Incomes.Add(_income1);
        _context.SaveChanges();
        _income1.Amount = 1200m;

        bool result = _repo.Update(_income1);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Delete_WithExistingIncome_ShouldReturnTrue()
    {
        _context.Incomes.Add(_income1);
        _context.SaveChanges();

        bool result = _repo.Delete(_income1);

        Assert.IsTrue(result);
    }
}
