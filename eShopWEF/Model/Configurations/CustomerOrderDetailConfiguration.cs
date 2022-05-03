using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Configurations
{
    public class CustomerOrderDetailConfiguration : IEntityTypeConfiguration<CustomerOrderDetail>
    {
        public void Configure(EntityTypeBuilder<CustomerOrderDetail> builder)
        {
			builder.Property(e => e.Quantity).HasDefaultValue(0);

			builder
				.HasKey(e => new { e.CustomerOrderId, e.ProductId });

			builder
				.HasOne(e => e.CustomerOrder)
				.WithMany(e => e.CustomerOrderDetail)
				.HasForeignKey(e => e.CustomerOrderId);

			builder
				.HasOne(e => e.Product)
				.WithMany(e => e.CustomerOrderDetail)
				.HasForeignKey(e => e.ProductId);
		}
    }
}
