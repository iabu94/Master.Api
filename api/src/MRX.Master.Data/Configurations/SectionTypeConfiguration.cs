using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRX.Master.Domain.Enums;
using MRX.Master.Domain.Models;
using System;
using System.Collections.Generic;

namespace MRX.Master.Data.Configurations
{
    internal class SectionTypeConfiguration : IEntityTypeConfiguration<SectionType>
    {
        public void Configure(EntityTypeBuilder<SectionType> builder)
        {
            builder.ToTable("SectionTypes");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Active).IsRequired()
                .HasDefaultValue(true);
            builder.Property(b => b.Deleted)
                .HasDefaultValue(false);
            builder.Property(b => b.CreatedDate)
                .HasDefaultValue(DateTime.Now);
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Type).IsRequired();
            builder.HasMany(b => b.Sections)
                .WithOne(b => b.SectionType);
            builder.HasData(new List<SectionType> {
                new SectionType
                {
                    Id = (int)SectionTypes.SingleChoice,
                    Type = SectionTypes.SingleChoice.ToString()
                },
                new SectionType
                {
                    Id = (int)SectionTypes.MultiChoice,
                    Type = SectionTypes.MultiChoice.ToString()
                }
            });
        }
    }
}
