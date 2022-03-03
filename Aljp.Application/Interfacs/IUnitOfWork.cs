namespace Aljp.Application.Interfacs;

public interface IUnitOfWork : IDisposable
{
    IVendorRepository Vendors { get; }
    
    int Complete();
    Task<int> CompleteAsync();
}