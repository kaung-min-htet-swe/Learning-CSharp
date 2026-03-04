using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.StudentModuleOne;

public class AddressService(CompanyContext db)
{
    private readonly CompanyContext _db = db;

    public async Task<Address> Create(Address address)
    {
        var res = _db.Addersses.Add(address);
        await _db.SaveChangesAsync();
        return res.Entity;
    }

    public async Task<List<Address>> GetAll()
    {
        return await _db.Addersses.ToListAsync();
    }

    public async Task<Address?> GetById(int id)
    {
        return await _db.Addersses.FirstOrDefaultAsync((a) => a.Id == id);
    }

    public async Task<Address?> Update(Address address)
    {
        var res = _db.Addersses.Update(address);
        await _db.SaveChangesAsync();

        return res.Entity;
    }

    public async Task<Address?> Delete(int id)
    {
        var address = await _db.Addersses.FirstOrDefaultAsync((a) => a.Id == id);
        if (address is null) return null;
        _db.Addersses.Remove(address);
        return address;
    }
}