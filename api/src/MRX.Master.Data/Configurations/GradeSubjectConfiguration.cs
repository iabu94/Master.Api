using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRX.Master.Domain.Models;
using System;

namespace MRX.Master.Data.Configurations
{
    internal class GradeSubjectConfiguration : IEntityTypeConfiguration<GradeSubject>
    {
        public void Configure(EntityTypeBuilder<GradeSubject> builder)
        {
            builder.ToTable("GradeSubjects");
            builder.HasKey(b => new { b.GradeId, b.SubjectId });
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.Active).IsRequired()
                .HasDefaultValue(true);
            builder.Property(b => b.Deleted)
                .HasDefaultValue(false);
            builder.Property(b => b.CreatedDate)
                .HasDefaultValue(DateTime.Now);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.HasOne(b => b.Grade)
                .WithMany(b => b.GradeSubjects)
                .HasForeignKey(b => b.GradeId);
            builder.HasOne(b => b.Subject)
                .WithMany(b => b.GradeSubjects)
                .HasForeignKey(b => b.SubjectId);
            builder.HasMany(b => b.Papers)
                .WithOne(b => b.GradeSubject);
        }
    }
}
