using _1015bookstore.data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.data.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails");
            builder.HasKey(x => new {x.product_id, x.order_id});
            builder.HasOne(x => x.product).WithMany(t=>t.orderdetails).HasForeignKey(t => t.product_id);
            builder.HasOne(x => x.order).WithMany(t => t.orderdetails).HasForeignKey(t => t.order_id);
            builder.Property(x => x.price).HasColumnType("decimal(18,2)");
            builder.Property(x => x.product_name).IsRequired().IsUnicode().HasMaxLength(100);
            builder.Property(x => x.imgpath).IsRequired(false);
        }
    }
}
