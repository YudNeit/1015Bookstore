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
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.HasOne(x => x.product).WithMany(t => t.carts).HasForeignKey(t => t.product_id);
            builder.HasOne(x => x.user).WithMany(t => t.carts).HasForeignKey(t => t.user_id);
            builder.Property(x => x.status).HasDefaultValue(CartStatus.Normal);
            builder.Property(x => x.price).HasColumnType("decimal(18,2)");
            builder.Property(x => x.product_name).IsRequired().IsUnicode().HasMaxLength(100);
            builder.Property(x => x.imgpath).IsRequired(false);
        }
    }
}
