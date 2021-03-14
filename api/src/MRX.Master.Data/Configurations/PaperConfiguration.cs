using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRX.Master.Domain.Models;
using System;

namespace MRX.Master.Data.Configurations
{
    internal class PaperConfiguration : IEntityTypeConfiguration<Paper>
    {
        public void Configure(EntityTypeBuilder<Paper> builder)
        {
            builder.ToTable("Papers");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.Active).IsRequired()
                .HasDefaultValue(true);
            builder.Property(b => b.Deleted)
                .HasDefaultValue(false);
            builder.Property(b => b.CreatedDate)
                .HasDefaultValue(DateTime.Now);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Description);
            builder.Property(p => p.TimeInMinutes);
            builder.Property(p => p.Marks);
            builder.HasOne(p => p.GradeSubject)
                .WithMany(gs => gs.Papers)
                .HasForeignKey(p => new { p.GradeId, p.SubjectId });
            builder.HasMany(p => p.Sections)
                .WithOne(s => s.Paper);
        }
    }
}
