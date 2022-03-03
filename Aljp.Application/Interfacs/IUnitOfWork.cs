namespace Aljp.Application.Interfacs;

public interface IUnitOfWork : IDisposable
{
    int Complete();
    Task<int> CompleteAsync();
}