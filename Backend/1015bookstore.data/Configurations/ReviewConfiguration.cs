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
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Reviews");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.HasOne(x => x.product).WithMany(t => t.reviews).HasForeignKey(t => t.product_id);
            builder.HasOne(x => x.user).WithMany(t => t.reviews).HasForeignKey(t => t.user_id);
            builder.Property(x=> x.content).IsUnicode();
            
        }
    }
}
