using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1015bookstore.data.Entities;

namespace _1015bookstore.data.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");

            builder.HasKey(x => x.id);

            builder.Property(x => x.id).UseIdentityColumn();
            builder.HasOne(x => x.user).WithMany(t => t.transactions).HasForeignKey(t => t.user_id);
            builder.Property(x => x.amount).HasColumnType("decimal(18,2)");
            builder.Property(x => x.fee).HasColumnType("decimal(18,2)");
        }
    }
}
