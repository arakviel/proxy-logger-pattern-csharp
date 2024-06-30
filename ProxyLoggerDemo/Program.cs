using ProxyLoggerDemo.Entities;
using ProxyLoggerDemo.Repository;

namespace ProxyLoggerDemo;

internal class Program
{
    static void Main(string[] args)
    {
        string logFilePath = "user_repository_log.txt";
        IUserRepository userRepository = new UserRepository();
        IUserRepository userProxyLoggerRepository = new UserProxyLoggerRepository(userRepository, logFilePath);

        // Додаємо користувачів
        var user1 = new User { Id = 1, Name = "John Doe", Email = "john@example.com" };
        var user2 = new User { Id = 2, Name = "Jane Smith", Email = "jane@example.com" };
        userProxyLoggerRepository.AddUser(user1);
        userProxyLoggerRepository.AddUser(user2);

        // Отримуємо користувача
        var retrievedUser = userProxyLoggerRepository.GetUser(1);
        Console.WriteLine($"Retrieved User: {retrievedUser.Name}, {retrievedUser.Email}");

        // Оновлюємо користувача
        retrievedUser.Name = "John Doe Jr.";
        userProxyLoggerRepository.UpdateUser(retrievedUser);

        // Видаляємо користувача
        userProxyLoggerRepository.DeleteUser(2);

        // Отримуємо всіх користувачів
        var allUsers = userProxyLoggerRepository.GetAllUsers();
        foreach (var user in allUsers)
        {
            Console.WriteLine($"User: {user.Name}, {user.Email}");
        }
    }
}
