
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application.Interfaces.IRepos;
using ProductCatalog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Infrastructure.Repos
{
    public class ProductRepo :GenericRepo<Product>
    {
        public ProductRepo(DbContext context)
               :base(context)
        {

        }
    }
}
