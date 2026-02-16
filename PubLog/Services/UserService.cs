using Microsoft.EntityFrameworkCore;
using PubLog.Data;
using PubLog.Models;

namespace PubLog.Services;

public class UserService
{
    private readonly PubLogDbContext _db;

    public UserService(PubLogDbContext db) => _db = db;

    public async Task<List<User>> GetAll()
    {
        return await _db.Users.OrderBy(u => u.Username).ToListAsync();
    }

    public async Task<User?> GetById(int id)
    {
        return await _db.Users.FindAsync(id);
    }

    public async Task<User> CreateUser(string username, string password, string displayName, UserRole role = UserRole.User)
    {
        var user = new User
        {
            Username = username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
            DisplayName = displayName,
            Role = role
        };
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        return user;
    }

    public async Task<bool> UsernameExists(string username)
    {
        return await _db.Users.AnyAsync(u => u.Username == username);
    }

    public async Task ToggleActive(int id)
    {
        var user = await _db.Users.FindAsync(id);
        if (user is not null)
        {
            user.IsActive = !user.IsActive;
            await _db.SaveChangesAsync();
        }
    }

    public async Task ChangePassword(int userId, string newPassword)
    {
        var user = await _db.Users.FindAsync(userId);
        if (user is not null)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            await _db.SaveChangesAsync();
        }
    }
}
