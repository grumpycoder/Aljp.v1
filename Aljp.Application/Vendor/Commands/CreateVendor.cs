using Aljp.Application.Interfaces;
using FluentValidation;
using MediatR; 

namespace Aljp.Application.Vendor.Commands;

public static class CreateVendor
{
    public record Command(string CompanyName, string CompanyWebsiteUrl, string SpinNumber,
        string PhoneNumber, string Street, string City, string State, string PostalCode) : IRequest<Response>;

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
    
    public class Handler : IRequestHandler<Command, Response>
    {
        private readonly IUnitOfWork _uow;

        public Handler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Response> Handle(Command request, CancellationToken token)
        {
            var entity = new Domain.Entities.Vendor(request.CompanyName, request.SpinNumber);
            entity.UpdateAddress(request.Street, request.City, request.State, request.PostalCode); 
            
            _uow.Vendors.Add(entity);
            await _uow.CompleteAsync();

            return new Response()
            {
                Id = entity.Id,
                CompanyName = entity.CompanyName,
                CompanyWebsiteUrl = entity.CompanyWebsiteUrl,
                SpinNumber = entity.SpinNumber,
                PhoneNumber = entity.PhoneNumber,
                Street = entity.Street,
                City = entity.City,
                State = entity.State,
                PostalCode = entity.PostalCode
            };
        }
    }

    public class Response
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string CompanyWebsiteUrl { get; set; } = string.Empty;
        public string SpinNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
    }
}