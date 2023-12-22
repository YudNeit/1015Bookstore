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
    public class UserUsePromotionalCodeConfiguration : IEntityTypeConfiguration<UserUsePromotionalCode>
    {
        public void Configure(EntityTypeBuilder<UserUsePromotionalCode> builder)
        {
            builder.ToTable("UsersUsePromotionalCodes");
            builder.HasKey(x => new {x.user_id, x.promotionalcode_id});
            builder.HasOne(x => x.promotionalcode).WithMany(t => t.usedpromotionalcode_lists).HasForeignKey(t => t.promotionalcode_id);
            builder.HasOne(x => x.user).WithMany(t => t.usedpromotionalcode_lists).HasForeignKey(t => t.user_id);
        }
    }
}
