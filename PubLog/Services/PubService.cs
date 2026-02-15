using Microsoft.EntityFrameworkCore;
using PubLog.Data;
using PubLog.Models;

namespace PubLog.Services;

public class PubService
{
    private readonly PubLogDbContext _db;

    public PubService(PubLogDbContext db) => _db = db;

    public async Task<List<Pub>> GetByArea(int areaId)
    {
        return await _db.Pubs
            .Where(p => p.AreaId == areaId)
            .OrderBy(p => p.Name)
            .ToListAsync();
    }

    public async Task<Pub?> GetById(int id)
    {
        return await _db.Pubs
            .Include(p => p.Area)
            .Include(p => p.Visits)
                .ThenInclude(v => v.User)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Pub>> GetAll()
    {
        return await _db.Pubs
            .Include(p => p.Area)
            .OrderBy(p => p.Name)
            .ToListAsync();
    }

    public async Task<Pub> Create(Pub pub)
    {
        _db.Pubs.Add(pub);
        await _db.SaveChangesAsync();
        return pub;
    }

    public async Task Update(Pub pub)
    {
        _db.Pubs.Update(pub);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var pub = await _db.Pubs.FindAsync(id);
        if (pub is not null)
        {
            _db.Pubs.Remove(pub);
            await _db.SaveChangesAsync();
        }
    }

    public async Task<List<Pub>> Search(string query)
    {
        return await _db.Pubs
            .Include(p => p.Area)
            .Where(p => p.Name.Contains(query) || p.Address.Contains(query))
            .OrderBy(p => p.Name)
            .ToListAsync();
    }
}
