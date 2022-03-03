using Aljp.Domain.Common;

namespace Aljp.Domain.Entities;

public class Vendor : DomainEntity
{
    public string CompanyName { get; set; } = string.Empty;
    public string CompanyWebsiteUrl { get; set; } = string.Empty; 
    public string SpinNumber { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
}