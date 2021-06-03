using CarryDoggyGo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryDoggyGo.Data.Mapping
{
    class QualificationMap : IEntityTypeConfiguration<Qualification>
    {
        public void Configure(EntityTypeBuilder<Qualification> builder)
        {
            builder.ToTable("qualification");
            builder.HasKey(u => u.QualificationId);
            builder.Property(u => u.QualificationId)
               .HasColumnName("qualification_id")
               .ValueGeneratedOnAdd();

            builder.Property(u => u.Reason)
                .HasMaxLength(300)
                .IsUnicode(false);

            builder.Property(dw => dw.Recommendation)
              .HasMaxLength(300)
              .IsUnicode(false);
        }
    }
}
