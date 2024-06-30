using ProxyLoggerDemo.Entities;

namespace ProxyLoggerDemo.Repository;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users = new List<User>();

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public User GetUser(int id)
    {
        return _users.Find(user => user.Id == id);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _users;
    }

    public void UpdateUser(User user)
    {
        var existingUser = GetUser(user.Id);
        if (existingUser != null)
        {
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
        }
    }

    public void DeleteUser(int id)
    {
        var user = GetUser(id);
        if (user != null)
        {
            _users.Remove(user);
        }
    }
}