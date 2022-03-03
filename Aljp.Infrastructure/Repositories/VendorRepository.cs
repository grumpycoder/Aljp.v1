using Aljp.Application.Interfaces;
using Aljp.Domain.Entities;
using Aljp.Infrastructure.Persistence;

namespace Aljp.Infrastructure.Repositories;

public class VendorRepository: Repository<Vendor>, IVendorRepository
{
    public VendorRepository(ApplicationDbContext context) : base(context)
    {
    }
 
}