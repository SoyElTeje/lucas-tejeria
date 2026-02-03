using System.Text.RegularExpressions;
using finance_manager;
using FinanceManager.DataAccess.Context;
using IDataAccess;

namespace FinanceManager.DataAccess.Repositories;

public class UserRepository(SqlContext context) : IUserRepository
{
    private readonly SqlContext _context = context;
    
    public User? GetUserById(string userId)
    {
        return _context.Users.FirstOrDefault(user => user.Id == userId);
    }

    public User? GetUserByEmail(string email)
    {
        return _context.Users.FirstOrDefault(user => user.Email == email);
    }

    public List<User> GetUsers()
    {
        return _context.Users.ToList();
    }

    public bool AddUser(User user)
    {
        if (!IsEmailAlreadyUsed(user.Email) && ValidEmailFormat(user.Email))
        {
            _context.Users.Add(user);
            return true;
        }
        return false;
    }

    public bool UpdateUser(User user)
    {
        if (ValidEmailFormat(user.Email))
        {
            _context.Users.Update(user);
            return true;
        } else{
            return false;
        }
    }

    private bool IsEmailAlreadyUsed(string email)
    {
        if (_context.Users.Any(user => user.Email == email))
        {
            return true;
        }
        return false;
    }

    private bool ValidEmailFormat(string email)
    {
        return Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
    }
}