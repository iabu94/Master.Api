using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRX.Master.Domain.Models;
using System;

namespace MRX.Master.Data.Configurations
{
    internal class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.ToTable("Sections");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.Active).IsRequired()
                .HasDefaultValue(true);
            builder.Property(b => b.Deleted)
                .HasDefaultValue(false);
            builder.Property(b => b.CreatedDate)
                .HasDefaultValue(DateTime.Now);
            builder.Property(s => s.Title);
            builder.HasOne(s => s.Paper)
                .WithMany(p => p.Sections)
                .HasForeignKey(s => s.PaperId);
            builder.HasOne(s => s.SectionType)
                .WithMany(t => t.Sections)
                .HasForeignKey(s => s.SectionTypeId);
            builder.HasMany(s => s.Questions)
                .WithOne(q => q.Section);
        }
    }
}
