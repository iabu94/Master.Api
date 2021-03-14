using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRX.Master.Domain.Models;
using System;

namespace MRX.Master.Data.Configurations
{
    internal class ChoiceConfiguration : IEntityTypeConfiguration<ChoiceInfo>
    {
        public void Configure(EntityTypeBuilder<ChoiceInfo> builder)
        {
            builder.ToTable("Choices");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.Active).IsRequired()
                .HasDefaultValue(true);
            builder.Property(b => b.Deleted)
                .HasDefaultValue(false);
            builder.Property(b => b.CreatedDate)
                .HasDefaultValue(DateTime.Now);
            builder.Property(b => b.Choice)
                .IsRequired();
            builder.Property(b => b.IsAnswer)
                .HasDefaultValue(false)
                .IsRequired();
            builder.HasOne(b => b.Question)
                .WithMany(b => b.Choices)
                .HasForeignKey(b => b.QuestionId);
            builder.HasMany(c => c.UserChoices)
                .WithOne(uc => uc.Choice);
        }
    }
}
