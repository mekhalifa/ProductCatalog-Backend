
using ProductCatalog.Application.Interfaces.IRepos;
using ProductCatalog.Domain;
using System;


namespace ProductCatalog.Application.Interfaces.IUnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepo<Product> Products { get; }
        int Complete();
    }
}
