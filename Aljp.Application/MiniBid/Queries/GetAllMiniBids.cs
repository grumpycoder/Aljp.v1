using Aljp.Application.Interfaces;
using MediatR;

namespace Aljp.Application.MiniBid.Queries;

public static class GetAllMiniBids
{
    public class Query : IRequest<IEnumerable<Domain.Entities.MiniBid>>
    {
    }
    
    public class Handler : IRequestHandler<Query,
        IEnumerable<Domain.Entities.MiniBid>>
    {
        private readonly IUnitOfWork _uow;

        public Handler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<Domain.Entities.MiniBid>> Handle(Query request,
            CancellationToken cancellationToken)
        {
            var list = await _uow.MiniBids.All();
            return list;
        }
    }
}