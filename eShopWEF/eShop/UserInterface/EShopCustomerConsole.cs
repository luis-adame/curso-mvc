using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UserInterface
{
    public partial class EShopConsole
    {
        private Boolean CustomerMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Add Items to Cart");
            Console.WriteLine("2. Remove Items from Cart");
            Console.WriteLine("3. Purchase Items");
            Console.WriteLine("Press any other Key to exit.");

            switch (Console.ReadLine())
            {
                case "1": break;
                case "2": break;
                case "3": break;
                default: return false;
            }

            return true;
        }
    }
}
