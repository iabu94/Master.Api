using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRX.Master.Domain.Models;
using System;

namespace MRX.Master.Data.Configurations
{
    internal class QuestionConfiguration : IEntityTypeConfiguration<QuestionInfo>
    {
        public void Configure(EntityTypeBuilder<QuestionInfo> builder)
        {
            builder.ToTable("Questions");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.Active).IsRequired()
                .HasDefaultValue(true);
            builder.Property(b => b.Deleted)
                .HasDefaultValue(false);
            builder.Property(b => b.CreatedDate)
                .HasDefaultValue(DateTime.Now);
            builder.Property(b => b.No).IsRequired();
            builder.Property(b => b.Question).IsRequired();
            builder.Property(b => b.Marks).IsRequired();
            builder.HasOne(q => q.Section)
                .WithMany(s => s.Questions)
                .HasForeignKey(q => q.SectionId);
            builder.HasMany(b => b.Choices)
                .WithOne(b => b.Question);
        }
    }
}
