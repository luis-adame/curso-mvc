using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public int SubdepartmentId { get; set; }
        public virtual Subdepartment Subdepartment { get; set; }
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
        public virtual ICollection<CustomerOrderDetail> CustomerOrderDetail { get; set; }
        public virtual ICollection<CartDetail> CartDetail { get; set; }

        public Product(string name, int stock, decimal price, string sku, string description, string brand, int subdepartmentId)
        {
            Name = name;
            Stock = stock;
            Price = price;
            Sku = sku;
            Description = description;
            Brand = brand;
            SubdepartmentId = subdepartmentId;
        }
    }
}
