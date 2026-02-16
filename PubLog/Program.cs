using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using PubLog.Components;
using PubLog.Data;
using PubLog.Models;
using PubLog.Services;

var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<PubLogDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.LogoutPath = "/logout";
        options.ExpireTimeSpan = TimeSpan.FromDays(30);
        options.SlidingExpiration = true;
    });
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

// Services
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<AreaService>();
builder.Services.AddScoped<PubService>();
builder.Services.AddScoped<VisitService>();

// Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Seed admin user
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PubLogDbContext>();
    await db.Database.MigrateAsync();

    if (!await db.Users.AnyAsync(u => u.Role == UserRole.Admin))
    {
        var config = app.Configuration.GetSection("AdminSeed");

        var username = config["Username"];
        var password = config["Password"];
        var displayname = config["DisplayName"];

        if (username is null || password is null || displayname is null)
            throw new Exception("Error fetching admin seeding information.");

        var admin = new User
        {
            Username = username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
            DisplayName = displayname,
            Role = UserRole.Admin
        };
        db.Users.Add(admin);
        await db.SaveChangesAsync();
    }
}

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
