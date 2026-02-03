using finance_manager;
using FinanceManager.DataAccess.Context;
using FinanceManager.DataAccess.Repositories;

namespace UserRepositoryTest;

[TestClass]
public class UserRepositoryTest
{
    private SqlContext _context = null!;
    private UserRepository _repo = null!;
    private User _user1 = null!;
    private User _user2 = null!;
    
    [TestInitialize]
    public void Setup()
    {
        var sqlContextFactory = new SqlContextFactory();
        _context = sqlContextFactory.CreateMemoryContext();
        _repo = new UserRepository(_context);
        _user1 = new User("Lucas", "Tejeria", "tejerialucas@test.com", "Password123!", new DateTime(2004, 10, 10));
        _user2 = new User("Tomas", "Tejeria", "tomastejeria@test.com", "Password123!", new DateTime(2007, 2, 22));
    }

    [TestCleanup]
    public void CleanUp()
    {
        _context.Dispose();
    }

    [TestMethod]
    public void GetUserById_WhitExistingId_ShouldReturnUser()
    {
        _context.Users.Add(_user1);
        _context.SaveChanges();
        
        User? foundUser = _repo.GetUserById(_user1.Id);
        
        Assert.IsNotNull(foundUser);
    }
    
    [TestMethod]
    public void AddUser_WithValidUser_ShouldReturnTrue()
    {
        bool result = _repo.AddUser(_user1);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void AddUser_WithInvalidEmail_ShouldReturnFalse()
    {
        _user2.Email = "invalidemail";
        bool result = _repo.AddUser(_user2);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void AddUser_WithAlreadyUsedEmail_ShouldReturnFalse()
    {
        _context.Users.Add(_user1);
        _context.SaveChanges();
        bool result = _repo.AddUser(_user1);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void UpdateUser_WithValidUser_ShouldReturnTrue()
    {
        _context.Users.Add(_user1);
        _context.SaveChanges();
        bool result = _repo.UpdateUser(_user1);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void UpdateUser_WithInvalidEmail_ShouldReturnFalse()
    {
        _user2.Email = "invalidemail";
        bool result = _repo.UpdateUser(_user2);
        Assert.IsFalse(result);
    }
}