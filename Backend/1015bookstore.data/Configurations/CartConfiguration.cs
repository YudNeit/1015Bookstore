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
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");
            builder.HasKey(x => new { x.product_id, x.user_id });
            builder.HasOne(x => x.product).WithMany(t => t.carts).HasForeignKey(t => t.product_id);
            builder.HasOne(x => x.user).WithMany(t => t.carts).HasForeignKey(t => t.user_id);
            builder.Property(x => x.price).HasColumnType("decimal(18,2)");
        }
    }
}
