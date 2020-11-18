using Ecommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(200);

            builder.Property(x => x.CodeName).HasMaxLength(100);

            builder.Property(x => x.Email).HasMaxLength(50);

            builder.Property(x => x.Phone).HasMaxLength(11);

            builder.Property(x => x.Fax).HasMaxLength(2000);

            //builder.HasOne(x => x.).WithMany(x => x.)
        }
    }
}
