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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.name).IsRequired().IsUnicode().HasMaxLength(100); ;
            builder.Property(x => x.alias).IsRequired().IsUnicode(false).HasMaxLength(100);
            builder.Property(x => x.price).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.start_count).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.buy_count).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.like_count).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.review_count).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.view_count).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.flashsale).HasDefaultValue(0);
            builder.Property(x => x.waranty).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.quanity).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.description).IsUnicode();

            builder.Property(x => x.brand).IsUnicode().HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.madein).IsUnicode().HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.suppiler).IsUnicode().HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.author).IsUnicode().HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.nop).IsUnicode().HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.mfgdate).IsRequired(false);
            builder.Property(x => x.yop).IsRequired(false);

            builder.Property(x => x.status).HasDefaultValue(ProductStatus.Normal);
            builder.Property(x => x.price).HasColumnType("decimal(18,2)");


        }
    }
}
