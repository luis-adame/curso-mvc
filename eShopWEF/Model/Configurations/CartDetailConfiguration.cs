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
    public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
			builder.Property(e => e.Quantity).HasDefaultValue(0);

			builder
				.HasKey(e => new { e.CartId, e.ProductId });

			builder
				.HasOne(e => e.Cart)
				.WithMany(e => e.CartDetail)
				.HasForeignKey(e => e.CartId);

			builder
				.HasOne(e => e.Product)
				.WithMany(e => e.CartDetail)
				.HasForeignKey(e => e.ProductId);
		}
    }
}
