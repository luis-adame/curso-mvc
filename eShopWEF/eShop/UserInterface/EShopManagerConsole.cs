using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UserInterface
{
    public partial class EShopConsole
    {
        private Boolean ManagerMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Register Product");
            Console.WriteLine("2. Edit Product");
            Console.WriteLine("3. Delete Product");
            Console.WriteLine("4. Search Product");
            Console.WriteLine("5. List Products");
            Console.WriteLine("6. Add Order");
            Console.WriteLine("7. List Orders");
            Console.WriteLine("8. Change Order status");
            Console.WriteLine("Press any other Key to exit.");

            switch (Console.ReadLine())
            {
                case "1":
                    RegisterProduct();
                    break;
                case "2":
                    EditProduct();
                    break;
                case "3":
                    DeleteProduct();
                    break;
                case "4":
                    SearchProduct();
                    break;
                case "5":
                    ListProducts();
                    break;
                case "6":
                    break;
                case "7":
                    break;
                case "8":
                    break;
                default: return false;
            }

            return true;
        }

        private void RegisterProduct()
        {
            var productInput = new ProductRegistryDto();
            var subdepartment = SelectSubdepartment();

            if (subdepartment is null)
                return;

            Console.Clear();
            Console.WriteLine("Please enter Product details.");

            try
            {
                Console.Write("Name: ");
                productInput.Name = Console.ReadLine();
                productInput.ValidateName();

                Console.Write("Stock: ");
                var numberInput = Console.ReadLine();

                if (!int.TryParse(numberInput, out int stock))
                    throw new Exception("Stock must be a number.");

                productInput.Stock = stock;
                productInput.ValidateStock();

                Console.Write("Price: ");
                numberInput = Console.ReadLine();

                if(!decimal.TryParse(numberInput, out decimal price))
                    throw new Exception("Price must be a number.");

                productInput.Price = price;
                productInput.ValidatePrice();

                Console.Write("Sku: ");
                productInput.Sku = Console.ReadLine();
                productInput.ValidateName();

                Console.Write("Description: ");
                productInput.Description = Console.ReadLine();

                Console.Write("Brand: ");
                productInput.Brand = Console.ReadLine();
                productInput.ValidateName();

                productInput.SubdepartmentId = subdepartment.Id;

                _productService.AddProduct(productInput);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
            }
        }

        private SubdepartmentDto SelectSubdepartment()
        {
            var departmentInput = new DepartmentRegistryDto();
            var subdepartmentInput = new SubdepartmentRegistryDto();

            Console.Clear();
            Console.WriteLine("Register Product.");
            Console.WriteLine("Select Department:");
            Console.WriteLine("Id\tName");

            try
            {
                var departments = _departmentService.GetDepartments();

                foreach (var department in departments)
                {
                    Console.WriteLine($"{department.Id}\t{department.Name}");
                }

                Console.Write("Option: ");
                var idInput = Console.ReadLine();

                if (string.IsNullOrEmpty(idInput))
                    throw new ApplicationException("Department Id not valid");
                if (!Int32.TryParse(idInput, out int departmentId))
                    throw new ApplicationException("Department Id must be a number.");

                departmentInput.Id = departmentId;
                departmentInput.ValidateId();

                var subdepartments = _departmentService.GetDepartmentSubdepartments(departmentInput);

                Console.Clear();
                Console.WriteLine("Select Subdepartment:");
                Console.WriteLine("Id\tName");

                foreach (var subdept in subdepartments)
                {
                    Console.WriteLine($"{subdept.Id}\t{subdept.Name}");
                }

                Console.Write("Option: ");
                idInput = Console.ReadLine();

                if (string.IsNullOrEmpty(idInput))
                    throw new ApplicationException("Department Id not valid");
                if (!Int32.TryParse(idInput, out int subdepartmentId))
                    throw new ApplicationException("Department Id must be a number.");

                subdepartmentInput.Id = subdepartmentId;
                subdepartmentInput.ValidateId();

                return _departmentService.GetSubdepartment(subdepartmentInput);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to continue.");
                Console.WriteLine();
            }

            return null;
        }

        private void EditProduct()
        {
            var productInput = new ProductRegistryDto();

            Console.Clear();
            Console.WriteLine("Edit Product.");
            Console.Write("Insert Product Id: ");
            var inputId = Console.ReadLine();

            try
            {
                if (!Int32.TryParse(inputId, out int productId))
                    throw new ApplicationException("Product Id must be a number.");

                productInput.Id = productId;
                productInput.ValidateId();

                var product = _productService.GetProduct(productInput);

                Console.WriteLine("Id\tName\t\tBrand\tPrice\tDescription");
                Console.WriteLine($"{product.Id}\t{product.Name}\t{product.Brand}\t{product.Price}\t{product.Description}\n");

                Console.WriteLine("Edit this product? (y/n)");

                if (!"y".Equals(Console.ReadLine()))
                    return;

                Console.Clear();
                Console.WriteLine("Please enter Product details.");

                Console.Write("Name: ");
                productInput.Name = Console.ReadLine();
                productInput.ValidateName();

                Console.Write("Stock: ");
                var numberInput = Console.ReadLine();

                if (!int.TryParse(numberInput, out int stock))
                    throw new Exception("Stock must be a number.");

                productInput.Stock = stock;
                productInput.ValidateStock();

                Console.Write("Price: ");
                numberInput = Console.ReadLine();

                if (!decimal.TryParse(numberInput, out decimal price))
                    throw new Exception("Price must be a number.");

                productInput.Price = price;
                productInput.ValidatePrice();

                Console.Write("Sku: ");
                productInput.Sku = Console.ReadLine();
                productInput.ValidateName();

                Console.Write("Description: ");
                productInput.Description = Console.ReadLine();

                Console.Write("Brand: ");
                productInput.Brand = Console.ReadLine();
                productInput.ValidateName();

                _productService.EditProduct(productInput);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
            }
        }

        private void DeleteProduct()
        {
            var productInput = new ProductRegistryDto();

            Console.Clear();
            Console.WriteLine("Delete Product.");
            Console.Write("Insert Product Id: ");
            var inputId = Console.ReadLine();

            try
            {
                if (!Int32.TryParse(inputId, out int productId))
                    throw new ApplicationException("Product Id must be a number.");

                productInput.Id = productId;
                productInput.ValidateId();

                var product = _productService.GetProduct(productInput);

                Console.WriteLine("Id\tName\t\tBrand\tPrice\tDescription");
                Console.WriteLine($"{product.Id}\t{product.Name}\t{product.Brand}\t{product.Price}\t{product.Description}\n");

                Console.WriteLine("Delete this product? (y/n)");

                if ("y".Equals(Console.ReadLine()))
                {
                    _productService.DeleteProduct(productInput);
                    Console.WriteLine("Product deleted.");
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
            }
        }

        private void SearchProduct()
        {
            var productInput = new ProductRegistryDto();

            Console.Clear();
            Console.WriteLine("Search Product.");
            Console.Write("Insert Product Id: ");
            var inputId = Console.ReadLine();

            try
            {
                if (!Int32.TryParse(inputId, out int productId))
                    throw new ApplicationException("Product Id must be a number.");

                productInput.Id = productId;
                productInput.ValidateId();

                var product = _productService.GetProduct(productInput);

                Console.WriteLine("Id\tName\t\tBrand\tPrice\tDescription");
                Console.WriteLine($"{product.Id}\t{product.Name}\t{product.Brand}\t{product.Price}\t{product.Description}");
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
            }
        }

        private void ListProducts()
        {
            Console.Clear();
            Console.WriteLine("Product List.");
            Console.WriteLine("Id\tName\t\tBrand\tPrice\tDescription");

            try
            {
                var products = _productService.GetProducts();

                foreach (var product in products)
                {
                    Console.WriteLine($"{product.Id}\t{product.Name}\t{product.Brand}\t{product.Price}\t{product.Description}");
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
            }
        }
    }
}
