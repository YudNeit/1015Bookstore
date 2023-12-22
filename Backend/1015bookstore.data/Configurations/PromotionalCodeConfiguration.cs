using _1015bookstore.data.Entities;
using _1015bookstore.data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.data.Configurations
{
    public class PromotionalCodeConfiguration : IEntityTypeConfiguration<PromotionalCode>
    {
        public void Configure(EntityTypeBuilder<PromotionalCode> builder)
        {
            builder.ToTable("PromotionalCodes");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.description).IsUnicode().HasMaxLength(1000);
            builder.Property(x => x.name).IsRequired().IsUnicode().HasMaxLength(100);
            builder.Property(x => x.discount_rate).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.code).IsRequired().IsUnicode(false).HasMaxLength(8);
            builder.Property(x => x.status).HasDefaultValue(PromotionalCodeStatus.Active);
            builder.Property(x => x.amount).HasDefaultValue(0);
        }
    }
}
