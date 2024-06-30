using ProxyLoggerDemo.Entities;

namespace ProxyLoggerDemo.Repository;

public class UserProxyLoggerRepository : IUserRepository
{
    private readonly IUserRepository _userRepository;
    private readonly string _logFilePath;

    public UserProxyLoggerRepository(IUserRepository userRepository, string logFilePath)
    {
        _userRepository = userRepository;
        _logFilePath = logFilePath;
    }

    public void AddUser(User user)
    {
        _userRepository.AddUser(user);
        Log($"Added user: {user.Name} (ID: {user.Id}, Email: {user.Email})");
    }

    public User GetUser(int id)
    {
        var user = _userRepository.GetUser(id);
        Log($"Retrieved user: {user?.Name} (ID: {id})");
        return user;
    }

    public IEnumerable<User> GetAllUsers()
    {
        var users = _userRepository.GetAllUsers();
        Log("Retrieved all users");
        return users;
    }

    public void UpdateUser(User user)
    {
        _userRepository.UpdateUser(user);
        Log($"Updated user: {user.Name} (ID: {user.Id}, Email: {user.Email})");
    }

    public void DeleteUser(int id)
    {
        _userRepository.DeleteUser(id);
        Log($"Deleted user with ID: {id}");
    }

    private void Log(string message)
    {
        using StreamWriter writer = new StreamWriter(_logFilePath, true);
        writer.WriteLine($"{DateTime.Now}: {message}");
    }
}