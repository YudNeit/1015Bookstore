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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.status).HasDefaultValue(OrderStatus.InProgress);
            builder.HasOne(x => x.user).WithMany(t => t.orders).HasForeignKey(t => t.user_id);
            builder.Property(x => x.name_reciver).IsRequired(false).HasMaxLength(100).IsUnicode();
            builder.Property(x => x.phone_reciver).IsRequired(false).HasMaxLength(10).IsUnicode(false);
            builder.Property(x => x.address_reciver).IsRequired(false).IsUnicode();
            builder.Property(x => x.paymentdate).IsRequired(false);
            builder.Property(x => x.deliverydate).IsRequired(false);
            builder.Property(x => x.completedate).IsRequired(false);
            builder.Property(x => x.isreview).HasDefaultValue(false);
            builder.Property(x => x.promotionalcode).IsRequired(false).HasMaxLength(8).IsUnicode(false);
            builder.Property(x => x.total).HasColumnType("decimal(18,2)");
        }
    }
}
