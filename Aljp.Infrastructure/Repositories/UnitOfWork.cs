using Aljp.Application.Interfacs;
using Aljp.Infrastructure.Persistence;

namespace Aljp.Infrastructure;

public class UnitOfWork: IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context, IVendorRepository vendors)
    {
        _context = context;
        Vendors = vendors;
    }
    
    public IVendorRepository Vendors { get; private set; }
    
    public int Complete()
    {
        return _context.SaveChanges();
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}