namespace Aljp.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IVendorRepository Vendors { get; }
    IMiniBidRepository MiniBids { get; }
    
    int Complete();
    Task<int> CompleteAsync();
}