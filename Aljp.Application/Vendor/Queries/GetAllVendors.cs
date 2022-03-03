using Aljp.Application.Interfaces;
using MediatR;

namespace Aljp.Application.Vendor.Queries;

public static class GetAllVendors
{
    public class Query : IRequest<IEnumerable<Domain.Entities.Vendor>>
    {
    }

    public class Handler : IRequestHandler<Query,
        IEnumerable<Domain.Entities.Vendor>>
    {
        private readonly IUnitOfWork _uow;

        public Handler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<Domain.Entities.Vendor>> Handle(Query request,
            CancellationToken cancellationToken)
        {
            var list = await _uow.Vendors.All();
            return list;
        }
    }
}