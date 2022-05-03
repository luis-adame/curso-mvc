using eShop.Services.Abstractions;
using eShop.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UserInterface
{
    public partial class EShopConsole
    {
        public readonly IProductService _productService;
        public readonly IDepartmentService _departmentService;

        public EShopConsole()
        {
            _productService = new ProductService();
            _departmentService = new DepartmentService();
        }

        public bool ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Select an Option.");
            Console.WriteLine("1. Customer.");
            Console.WriteLine("2. Manager.");
            Console.WriteLine("Press any other Key to exit.");

            switch (Console.ReadLine())
            {
                case "1": 
                    while (CustomerMenu());
                    break;
                case "2":
                    while (ManagerMenu()) ;
                    break;

                default: return false;
            }

            return true;
        }
    }
}
