﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasIndex(e => e.Name).IsUnique();
            builder.Property(e => e.Stock).HasDefaultValue(0);
            builder.Property(e => e.Price).HasDefaultValue(0).HasPrecision(18,2);
        }
    }
}
