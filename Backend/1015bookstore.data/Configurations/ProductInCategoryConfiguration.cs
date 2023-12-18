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
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.ToTable("ProductInCategory");
            builder.HasKey(x => new { x.product_id, x.category_id });
            builder.HasOne(x => x.product).WithMany(t => t.productincategory).HasForeignKey(t => t.product_id);
            builder.HasOne(x => x.category).WithMany(t => t.productincategory).HasForeignKey(t => t.category_id);
        }
    }
}
