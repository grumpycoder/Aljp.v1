using Aljp.Application.Common.Exceptions;
using Aljp.Application.Interfaces;
using MediatR;

namespace Aljp.Application.MiniBid.Queries;

public static class GetMiniBidById
{
    public class Query : IRequest<Domain.Entities.MiniBid>
    {
        public int Id { get; }

        public Query(int id)
        {
            Id = id;
        }
    }

    public class Handler : IRequestHandler<Query, Domain.Entities.MiniBid>
    {
        private readonly IUnitOfWork _uow;

        public Handler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Domain.Entities.MiniBid> Handle(Query request,
            CancellationToken cancellationToken)
        {
            var entity = await _uow.MiniBids.GetById(request.Id);

            if (entity == null) throw new NotFoundException(nameof(Domain.Entities.MiniBid), request.Id);

            return entity;
        }
    }
}