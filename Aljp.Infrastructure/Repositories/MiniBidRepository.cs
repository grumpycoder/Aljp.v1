using Aljp.Application.Interfaces;
using Aljp.Domain.Entities;
using Aljp.Infrastructure.Persistence;

namespace Aljp.Infrastructure.Repositories;

public class MiniBidRepository : Repository<MiniBid>, IMiniBidRepository
{
    public MiniBidRepository(ApplicationDbContext context) : base(context)
    {
    }
}