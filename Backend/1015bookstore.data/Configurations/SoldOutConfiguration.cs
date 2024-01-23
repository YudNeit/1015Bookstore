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
    public class SoldOutConfiguration : IEntityTypeConfiguration<SoldOut>
    {
        public void Configure(EntityTypeBuilder<SoldOut> builder)
        {
            builder.ToTable("SoldOuts");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.HasOne(x => x.user).WithMany(t => t.sold_outs).HasForeignKey(t => t.user_id);
            builder.Property(x => x.total).HasColumnType("decimal(18,2)");
        }
    }
}
