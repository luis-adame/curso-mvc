using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AppDbContextSeed
    {
        public static Task SeedAsync(AppDbContext context)
        {
			if (!context.Departments.Any())
			{
				var seedDepartments = new List<Department>
				{
					new Department { Name = "Electronics" },
					new Department { Name = "House" },
					new Department { Name = "Grocery" }
				};

				foreach (var department in seedDepartments)
				{
					context.Departments.Add(department);
				}
				context.SaveChanges();
			}

            if (!context.Subdepartments.Any())
            {
				var seedSubdepartments = new List<Subdepartment>();

				var department1 = context.Departments.FirstOrDefault(e => e.Name.ToLower().Equals("Electronics".ToLower()));

                if (!(department1 is null))
                {
					seedSubdepartments.Add(new Subdepartment("Cell Phones", department1.Id));
					seedSubdepartments.Add(new Subdepartment("Tvs and Home Theater", department1.Id));
					seedSubdepartments.Add(new Subdepartment("Video Games", department1.Id));
				}

				var department2 = context.Departments.FirstOrDefault(e => e.Name.ToLower().Equals("House".ToLower()));

				if (!(department2 is null))
				{
					seedSubdepartments.Add(new Subdepartment("Furniture", department2.Id));
					seedSubdepartments.Add(new Subdepartment("Bath", department2.Id));
					seedSubdepartments.Add(new Subdepartment("Kitchen and Dining", department2.Id));
				}

				var department3 = context.Departments.FirstOrDefault(e => e.Name.ToLower().Equals("Grocery".ToLower()));

				if (!(department3 is null))
				{
					seedSubdepartments.Add(new Subdepartment("Beverages", department3.Id));
					seedSubdepartments.Add(new Subdepartment("Snacks", department3.Id));
					seedSubdepartments.Add(new Subdepartment("Wine, Beer and Liquors", department3.Id));
				}
				
                foreach (var subdepartment in seedSubdepartments)
                {
					if (!(department1 is null) && subdepartment.DepartmentId.Equals(department1.Id))
					{
						var subdept = context.Subdepartments.Add(subdepartment);
						department1.Subdepartments.Add(subdept.Entity);
					}
					else if (!(department2 is null) && subdepartment.DepartmentId.Equals(department2.Id))
                    {
						var subdept = context.Subdepartments.Add(subdepartment);
						department2.Subdepartments.Add(subdept.Entity);
					}
					else if (!(department3 is null) && subdepartment.DepartmentId.Equals(department3.Id))
					{
						var subdept = context.Subdepartments.Add(subdepartment);
						department3.Subdepartments.Add(subdept.Entity);
					}
				}

				context.SaveChanges();
			}

            if (!context.Products.Any())
            {
				var seedProducts = new List<Product>();
				var subdepartment = context.Subdepartments.FirstOrDefault(e => e.Name.ToLower().Equals("Video Games".ToLower()));

                if (!(subdepartment is null))
                {
					seedProducts.Add(new Product("PlayStation 4", 50, 299.99m, "00002132", "1tb Console", "Sony", subdepartment.Id));
					seedProducts.Add(new Product("Xbox One S", 50, 299.99m, "00012442", "512gb Console", "Microsoft", subdepartment.Id));
					seedProducts.Add(new Product("Nintendo Switch", 50, 299.99m, "00302198", "32Ggb Console", "Nintendo", subdepartment.Id));

					foreach (var product in seedProducts)
					{
						var prod = context.Products.Add(product);
						subdepartment.Products.Add(prod.Entity);
					}
					context.SaveChanges();
				}
			}

            if (!context.Providers.Any())
            {
				var seedProviders = new List<Provider>
				{
					new Provider { Name = "Pacific Grocery Suppliers", Address = "8392 Gogo Ave", PhoneNumber = "5550234011", EmailAddress = "pacificg@hotmail.com", City = "Angels"},
					new Provider { Name = "Vortex Technologies", Address = "5234 something Ave", PhoneNumber = "3339480024", EmailAddress = "vortexe@outlook.com", City = "Mombasa"},
					new Provider { Name = "Kali Imports", Address = "7654 twist Ave", PhoneNumber = "8889346471", EmailAddress = "kalii@live.com", City = "Wakanda"}
				};
				foreach (var provider in seedProviders)
				{
					context.Providers.Add(provider);
				}
				context.SaveChanges();
			}

			return Task.CompletedTask;
		}
    }
}
