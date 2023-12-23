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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(x => x.firstname).IsRequired().HasMaxLength(100);
            builder.Property(x => x.lastname).IsRequired().HasMaxLength(100);
            builder.Property(x => x.dob).IsRequired(false);
            builder.Property(x => x.sex).IsRequired(false);
        }
    }
}
