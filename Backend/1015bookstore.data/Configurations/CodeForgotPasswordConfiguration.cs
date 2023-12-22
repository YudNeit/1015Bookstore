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
    public class CodeForgotPasswordConfiguration : IEntityTypeConfiguration<CodeForgotPassword>
    {
        public void Configure(EntityTypeBuilder<CodeForgotPassword> builder)
        {
            builder.ToTable("CodesForgotPassword");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.code).IsUnicode(false).IsRequired(true).HasMaxLength(6);
            builder.HasOne(x => x.user).WithMany(x => x.codes).HasForeignKey(x => x.user_id);
            builder.Property(x => x.token).IsUnicode(false).IsRequired(true);
            builder.Property(x => x.check).HasDefaultValue(false);
        }
    }
}
