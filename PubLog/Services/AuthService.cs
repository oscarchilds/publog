using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using PubLog.Data;
using PubLog.Models;

namespace PubLog.Services;

public class AuthService
{
    private readonly PubLogDbContext _db;

    public AuthService(PubLogDbContext db) => _db = db;

    public async Task<User?> ValidateCredentials(string username, string password)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == username && u.IsActive);
        if (user is null) return null;
        return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash) ? user : null;
    }

    public ClaimsPrincipal CreateClaimsPrincipal(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Username),
            new("DisplayName", user.DisplayName),
            new(ClaimTypes.Role, user.Role.ToString())
        };
        var identity = new ClaimsIdentity(claims, "PubLogAuth");
        return new ClaimsPrincipal(identity);
    }
}
