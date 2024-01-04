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
    public class ReportDataConfiguration : IEntityTypeConfiguration<ReportData>
    {
        public void Configure(EntityTypeBuilder<ReportData> builder)
        {
            builder.ToTable("ReportDatas");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
        }
    }
}
