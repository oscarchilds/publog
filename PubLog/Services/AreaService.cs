using Microsoft.EntityFrameworkCore;
using PubLog.Data;
using PubLog.Models;

namespace PubLog.Services;

public class AreaService
{
    private readonly PubLogDbContext _db;

    public AreaService(PubLogDbContext db) => _db = db;

    public async Task<List<Area>> GetAll()
    {
        return await _db.Areas.OrderBy(a => a.Name).ToListAsync();
    }

    public async Task<List<Area>> GetAllWithPubCount()
    {
        return await _db.Areas
            .Include(a => a.Pubs)
            .OrderBy(a => a.Name)
            .ToListAsync();
    }

    public async Task<Area?> GetById(int id)
    {
        return await _db.Areas
            .Include(a => a.Pubs)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Area> Create(string name)
    {
        var area = new Area { Name = name };
        _db.Areas.Add(area);
        await _db.SaveChangesAsync();
        return area;
    }

    public async Task Update(Area area)
    {
        _db.Areas.Update(area);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var area = await _db.Areas.FindAsync(id);
        if (area is not null)
        {
            _db.Areas.Remove(area);
            await _db.SaveChangesAsync();
        }
    }

    public async Task<bool> NameExists(string name, int? excludeId = null)
    {
        return await _db.Areas.AnyAsync(a => a.Name == name && (excludeId == null || a.Id != excludeId));
    }
}
