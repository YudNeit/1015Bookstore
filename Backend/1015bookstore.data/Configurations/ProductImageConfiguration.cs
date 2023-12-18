using _1015bookstore.data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.data.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductImages");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x=>x.imagepath).IsRequired();
            builder.Property(x => x.caption).IsRequired().HasMaxLength(200).IsUnicode();

            builder.HasOne(x => x.product).WithMany(t => t.productimages).HasForeignKey(t => t.product_id);
        }
    }
}
