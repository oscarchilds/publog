using Microsoft.EntityFrameworkCore;
using PubLog.Data;
using PubLog.Models;

namespace PubLog.Services;

public class VisitService
{
    private readonly PubLogDbContext _db;

    public VisitService(PubLogDbContext db) => _db = db;

    public async Task<List<Visit>> GetByPub(int pubId)
    {
        return await _db.Visits
            .Include(v => v.User)
            .Where(v => v.PubId == pubId)
            .OrderByDescending(v => v.VisitDate)
            .ToListAsync();
    }

    public async Task<List<Visit>> GetByUser(int userId)
    {
        return await _db.Visits
            .Include(v => v.Pub)
                .ThenInclude(p => p.Area)
            .Where(v => v.UserId == userId)
            .OrderByDescending(v => v.VisitDate)
            .ToListAsync();
    }

    public async Task<Visit?> GetByUserAndPub(int userId, int pubId)
    {
        return await _db.Visits
            .FirstOrDefaultAsync(v => v.UserId == userId && v.PubId == pubId);
    }

    public async Task<Visit> Create(Visit visit)
    {
        visit.CreatedAt = DateTime.UtcNow;
        visit.UpdatedAt = DateTime.UtcNow;
        _db.Visits.Add(visit);
        await _db.SaveChangesAsync();
        return visit;
    }

    public async Task Update(Visit visit)
    {
        visit.UpdatedAt = DateTime.UtcNow;
        _db.Visits.Update(visit);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var visit = await _db.Visits.FindAsync(id);
        if (visit is not null)
        {
            _db.Visits.Remove(visit);
            await _db.SaveChangesAsync();
        }
    }

    public async Task<(int PubsVisited, int TotalPubs)> GetUserStats(int userId)
    {
        var visited = await _db.Visits.CountAsync(v => v.UserId == userId);
        var total = await _db.Pubs.CountAsync();
        return (visited, total);
    }

    public async Task<HashSet<int>> GetVisitedPubIds(int userId)
    {
        var ids = await _db.Visits
            .Where(v => v.UserId == userId)
            .Select(v => v.PubId)
            .ToListAsync();
        return ids.ToHashSet();
    }
}
