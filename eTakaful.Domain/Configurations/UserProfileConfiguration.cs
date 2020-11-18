using Ecommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Configurations
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("UserProfiles");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Address).HasMaxLength(200);

            builder.Property(x => x.Email).HasMaxLength(100);

            builder.Property(x => x.Phone).HasMaxLength(11);

            builder.Property(x => x.Avatar).HasMaxLength(200);

            //builder.HasOne(x => x.User).WithOne(x => x.UserProfile).HasForeignKey<UserProfile>(x => x.UserId);
        }
    }
}
