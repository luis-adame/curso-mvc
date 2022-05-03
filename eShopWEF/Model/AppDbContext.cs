using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Model
{
    public class AppDbContext : DbContext
	{
		public DbSet<Cart> Carts { get; set; }
		public DbSet<CartDetail> CartDetail { get; set; }
		public DbSet<CustomerOrder> CustomerOrders { get; set; }
		public DbSet<CustomerOrderDetail> CustomerOrderDetail { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Provider> Providers { get; set; }
		public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
		public DbSet<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
		public DbSet<Subdepartment> Subdepartments { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new CartConfiguration());
			builder.ApplyConfiguration(new CartDetailConfiguration());
			builder.ApplyConfiguration(new CustomerOrderConfiguration());
			builder.ApplyConfiguration(new CustomerOrderDetailConfiguration());
			builder.ApplyConfiguration(new DepartmentConfiguration());
			builder.ApplyConfiguration(new ProductConfiguration());
			builder.ApplyConfiguration(new ProviderConfiguration());
			builder.ApplyConfiguration(new PurchaseOrderConfiguration());
			builder.ApplyConfiguration(new PurchaseOrderDetailConfiguration());
			builder.ApplyConfiguration(new SubdepartmentConfiguration());
		}
		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EShop;Integrated Security=True");
		}
	}
}