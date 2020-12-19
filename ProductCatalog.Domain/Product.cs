using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Domain
{
    public class Product
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public double Price { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
