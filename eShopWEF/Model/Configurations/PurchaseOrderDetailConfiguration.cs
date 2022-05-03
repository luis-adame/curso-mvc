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
    public class PurchaseOrderDetailConfiguration : IEntityTypeConfiguration<PurchaseOrderDetail>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrderDetail> builder)
        {
			builder.Property(e => e.Quantity).HasDefaultValue(0);

			builder
				.HasKey(e => new { e.PurchaseOrderId, e.ProductId });

			builder
				.HasOne(e => e.PurchaseOrder)
				.WithMany(e => e.PurchaseOrderDetail)
				.HasForeignKey(e => e.PurchaseOrderId);

			builder
				.HasOne(e => e.Product)
				.WithMany(e => e.PurchaseOrderDetail)
				.HasForeignKey(e => e.ProductId);
		}
    }
}
