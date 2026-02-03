using finance_manager;
using FinanceManager.DataAccess.Context;
using FinanceManager.DataAccess.Repositories;

namespace UserRepositoryTest;

[TestClass]
public class CurrencyRepositoryTests
{
    private SqlContext _context = null!;
    private CurrencyRepository _repo = null!;
    private Currency _currencyUsd = null!;
    private Currency _currencyEur = null!;

    [TestInitialize]
    public void Setup()
    {
        _context = new SqlContextFactory().CreateMemoryContext();
        _repo = new CurrencyRepository(_context);
        _currencyUsd = new Currency("USD", "Dólar estadounidense", "$");
        _currencyEur = new Currency("EUR", "Euro", "€");
    }

    [TestCleanup]
    public void CleanUp() => _context.Dispose();

    [TestMethod]
    public void GetById_WithExistingId_ShouldReturnCurrency()
    {
        _context.Currencies.Add(_currencyUsd);
        _context.SaveChanges();

        Currency? found = _repo.GetById(_currencyUsd.Id);

        Assert.IsNotNull(found);
        Assert.AreEqual(_currencyUsd.Id, found.Id);
        Assert.AreEqual("USD", found.Code);
        Assert.AreEqual("Dólar estadounidense", found.FullName);
        Assert.AreEqual("$", found.Symbol);
    }

    [TestMethod]
    public void GetById_WithNonExistingId_ShouldReturnNull()
    {
        Currency? found = _repo.GetById(Guid.NewGuid().ToString());
        Assert.IsNull(found);
    }

    [TestMethod]
    public void GetByCode_WithExistingCode_ShouldReturnCurrency()
    {
        _context.Currencies.Add(_currencyUsd);
        _context.SaveChanges();

        Currency? found = _repo.GetByCode("USD");

        Assert.IsNotNull(found);
        Assert.AreEqual("USD", found.Code);
        Assert.AreEqual("$", found.Symbol);
    }

    [TestMethod]
    public void GetByCode_WithNonExistingCode_ShouldReturnNull()
    {
        Currency? found = _repo.GetByCode("XXX");
        Assert.IsNull(found);
    }

    [TestMethod]
    public void GetAll_WithNoCurrencies_ShouldReturnEmptyList()
    {
        List<Currency> list = _repo.GetAll();
        Assert.IsNotNull(list);
        Assert.AreEqual(0, list.Count);
    }

    [TestMethod]
    public void GetAll_WithCurrencies_ShouldReturnAllOrderedByCode()
    {
        _context.Currencies.Add(_currencyEur);
        _context.Currencies.Add(_currencyUsd);
        _context.SaveChanges();

        List<Currency> list = _repo.GetAll();

        Assert.AreEqual(2, list.Count);
        Assert.AreEqual("EUR", list[0].Code);
        Assert.AreEqual("USD", list[1].Code);
    }

    [TestMethod]
    public void Add_WithValidCurrency_ShouldReturnTrue()
    {
        bool result = _repo.Add(_currencyUsd);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Update_WithValidCurrency_ShouldReturnTrue()
    {
        _context.Currencies.Add(_currencyUsd);
        _context.SaveChanges();
        _currencyUsd.Symbol = "US$";

        bool result = _repo.Update(_currencyUsd);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Delete_WithExistingCurrency_ShouldReturnTrue()
    {
        _context.Currencies.Add(_currencyUsd);
        _context.SaveChanges();

        bool result = _repo.Delete(_currencyUsd);

        Assert.IsTrue(result);
    }
}
