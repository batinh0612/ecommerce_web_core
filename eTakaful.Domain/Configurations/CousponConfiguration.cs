using Ecommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Configurations
{
    public class CousponConfiguration : IEntityTypeConfiguration<Couspon>
    {
        public void Configure(EntityTypeBuilder<Couspon> builder)
        {
            
        }
    }
}
