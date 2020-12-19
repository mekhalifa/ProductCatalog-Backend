using ProductCatalog.Application.Interfaces.IRepos;
using ProductCatalog.Application.Interfaces.IUnitOfWorks;
using ProductCatalog.Domain;
using ProductCatalog.Infrastructure.Repos;
using ProductCatalog.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductCatalogContext _context;
        private IGenericRepo<Product> _products;

        public UnitOfWork(ProductCatalogContext context)
        {
            _context = context;
        }

        public IGenericRepo<Product> Products
        {
            get
            {
                if(_products == null)
                {
                    _products = new ProductRepo(_context);
                }
                return _products;
            }
        }
        

        public int Complete()
        {
          return  _context.SaveChanges();
        }



        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
