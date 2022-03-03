namespace Aljp.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IVendorRepository Vendors { get; }
    
    int Complete();
    Task<int> CompleteAsync();
}