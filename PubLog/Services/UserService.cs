using Microsoft.EntityFrameworkCore;
using PubLog.Data;
using PubLog.Models;

namespace PubLog.Services;

public class UserService
{
    private readonly PubLogDbContext _db;

    public UserService(PubLogDbContext db) => _db = db;

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
}
