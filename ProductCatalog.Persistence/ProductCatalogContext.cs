using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain;
using ProductCatalog.Persistence.SeedData;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Persistence
{
    public class ProductCatalogContext:DbContext
    {

        
        public ProductCatalogContext(DbContextOptions<ProductCatalogContext> options ):base(options)
        {

        }


        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedProducts();

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
