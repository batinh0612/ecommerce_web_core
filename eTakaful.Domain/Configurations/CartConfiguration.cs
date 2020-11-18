using Ecommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ShoppingNumber).IsRequired().HasMaxLength(11);

            builder.Property(x => x.TotalPrice).IsRequired();

            //builder.HasOne(x => x.CartDetail).WithMany(x => x.).HasForeignKey(x => x.UserId);
        }
    }
}
