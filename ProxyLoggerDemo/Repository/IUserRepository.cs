using ProxyLoggerDemo.Entities;

namespace ProxyLoggerDemo.Repository;

public interface IUserRepository
{
    void AddUser(User user);
    User GetUser(int id);
    IEnumerable<User> GetAllUsers();
    void UpdateUser(User user);
    void DeleteUser(int id);
}