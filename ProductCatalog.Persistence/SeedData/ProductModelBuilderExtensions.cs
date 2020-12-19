using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Persistence.SeedData
{
    public static class ProductModelBuilderExtensions
    {
        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Product 1", Price = 10, Photo = "Images/default-image.jpg", LastUpdated = DateTime.Now },
                new Product { Id = 2, Name = "Product 2", Price = 20, Photo = "Images/default-image.jpg", LastUpdated = DateTime.Now.AddDays(-1) },
                new Product { Id = 3, Name = "Product 3", Price = 30, Photo = "Images/default-image.jpg", LastUpdated = DateTime.Now.AddDays(-2) },
                new Product { Id = 4, Name = "Product 4", Price = 40, Photo = "Images/default-image.jpg", LastUpdated = DateTime.Now.AddDays(-2) },
                new Product { Id = 5, Name = "Product 5", Price = 50, Photo = "Images/default-image.jpg", LastUpdated = DateTime.Now.AddDays(-3) }
                );
        }
    }
}
