using eShop.Services.Abstractions;
using Model;
using Model.Entities;
using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService()
        {
            _context = new AppDbContext();
        }

        public void AddProduct(ProductRegistryDto productRegistry)
        {
            var product = new Product(productRegistry.Name, productRegistry.Stock, productRegistry.Price, productRegistry.Sku, productRegistry.Description, productRegistry.Brand, productRegistry.SubdepartmentId);

            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteProduct(ProductRegistryDto productRegistry)
        {
            var product = _context.Products.FirstOrDefault(e => e.Id.Equals(productRegistry.Id));

            if (product is null)
                throw new Exception("Product not found.");

            try
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EditProduct(ProductRegistryDto productRegistry)
        {
            var product = _context.Products.Where(c => c.Id.Equals(productRegistry.Id)).FirstOrDefault();

            if (product is null)
                throw new Exception("Product does not exists.");
            else
            {
                product.Name = productRegistry.Name;
                product.Stock = productRegistry.Stock;
                product.Price = productRegistry.Price;
                product.Sku = productRegistry.Sku;
                product.Description = productRegistry.Description;
                product.Brand = productRegistry.Brand;

                _context.SaveChanges();
            }
        }

        public List<ProductDto> GetDepartmentProducts(DepartmentRegistryDto departmentRegistry)
        {
            throw new NotImplementedException();
        }

        public ProductDto GetProduct(ProductRegistryDto productRegistry)
        {
            var product = _context.Products.Select(e => new ProductDto
            {
                Id = e.Id,
                Name = e.Name,
                Stock = e.Stock,
                Price = e.Price,
                Sku = e.Sku,
                Description = e.Description,
                Brand = e.Brand,
            }).FirstOrDefault(e => e.Id.Equals(productRegistry.Id));

            if (product is null)
                throw new Exception("Product not found.");

            return product;
        }

        public List<ProductDto> GetProducts()
        {
            var products = _context.Products.Select(e => new ProductDto
            {
                Id = e.Id,
                Name = e.Name,
                Stock = e.Stock,
                Price = e.Price,
                Sku = e.Sku,
                Description = e.Description,
                Brand = e.Brand,
            }).ToList();

            if (!products.Any())
                throw new Exception("There are no products.");

            return products;
        }

        public List<ProductDto> GetSubDepartmentProducts(SubdepartmentRegistryDto subdepartmentRegistry)
        {
            throw new NotImplementedException();
        }
    }
}
