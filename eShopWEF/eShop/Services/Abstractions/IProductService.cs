using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Services.Abstractions
{
    public interface IProductService
    {
        public List<ProductDto> GetProducts();
        public ProductDto GetProduct(ProductRegistryDto productRegistry);
        public List<ProductDto> GetSubDepartmentProducts(SubdepartmentRegistryDto subdepartmentRegistry);
        public List<ProductDto> GetDepartmentProducts(DepartmentRegistryDto departmentRegistry);
        public void AddProduct(ProductRegistryDto productRegistry);
        public void EditProduct(ProductRegistryDto productRegistry);
        public void DeleteProduct(ProductRegistryDto productRegistry);
    }
}
