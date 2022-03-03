using Aljp.Application.Common.Exceptions;
using Aljp.Application.Interfaces;
using MediatR;

namespace Aljp.Application.Vendor.Queries;

public static class GetVendorById
{
    public class Query : IRequest<Domain.Entities.Vendor>
    {
        public int Id { get; }

        public Query(int id)
        {
            Id = id;
        }
    }

    public class
        Handler : IRequestHandler<Query, Domain.Entities.Vendor>
    {
        private readonly IUnitOfWork _uow;

        public Handler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Domain.Entities.Vendor> Handle(Query request,
            CancellationToken cancellationToken)
        {
            var entity = await _uow.Vendors.GetById(request.Id); 
            
            if (entity == null) throw new NotFoundException(nameof(Domain.Entities.Vendor), request.Id);

            return entity;
        }
    }
}