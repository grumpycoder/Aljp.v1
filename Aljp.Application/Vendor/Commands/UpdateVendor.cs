using Aljp.Application.Common.Exceptions;
using Aljp.Application.Interfaces;
using FluentValidation;
using MediatR;

namespace Aljp.Application.Vendor.Commands;

public static class UpdateVendor
{
    public record Command(int Id, string CompanyName, string CompanyWebsiteUrl, string SpinNumber,
        string PhoneNumber, string Street, string City, string State, string PostalCode) : IRequest;
    
    public class Validator: AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(v => v.CompanyName)
                .NotEmpty().WithMessage("Company Name is required.")
                .MaximumLength(250).WithMessage("Company Name must not exceed 250 characters."); 
            
            RuleFor(v => v.SpinNumber)
                .MaximumLength(10).WithMessage("SPIN Number cannot exceed 10."); 
        }

    }
    
    public class Handler : IRequestHandler<Command>
    {
        private readonly IUnitOfWork _uow;

        public Handler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Unit> Handle(Command request, CancellationToken token)
        {
            var entity = await _uow.Vendors.GetById(request.Id);

            if (entity == null) throw new NotFoundException(nameof(Domain.Entities.Vendor));

            entity.UpdateCompany(request.CompanyName, request.CompanyWebsiteUrl, request.SpinNumber); 
            
            entity.UpdateAddress(request.Street, request.City, request.State, request.PostalCode);

            entity.UpdatePhone(request.PhoneNumber);
            
            await _uow.CompleteAsync();
            return Unit.Value; 
        }
    }
}