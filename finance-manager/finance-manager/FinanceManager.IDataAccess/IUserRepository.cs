using finance_manager;

namespace IDataAccess;

public interface IUserRepository
{
    User? GetUserById(string userId);
    User? GetUserByEmail(string email);
    List<User> GetUsers();
    bool AddUser(User user);
    bool UpdateUser(User user);
}