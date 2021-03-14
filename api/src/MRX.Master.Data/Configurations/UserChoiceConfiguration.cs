using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRX.Master.Domain.Models;
using System;

namespace MRX.Master.Data.Configurations
{
    internal class UserChoiceConfiguration : IEntityTypeConfiguration<UserChoice>
    {
        public void Configure(EntityTypeBuilder<UserChoice> builder)
        {
            builder.ToTable("UserChoices");
            builder.HasKey(b => new { b.UserId, b.ChoiceId });
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.Active).IsRequired()
                .HasDefaultValue(true);
            builder.Property(b => b.Deleted)
                .HasDefaultValue(false);
            builder.Property(b => b.CreatedDate)
                .HasDefaultValue(DateTime.Now);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.HasOne(b => b.User)
                .WithMany(b => b.UserChoices)
                .HasForeignKey(b => b.UserId);
            builder.HasOne(b => b.Choice)
                .WithMany(b => b.UserChoices)
                .HasForeignKey(b => b.ChoiceId);
        }
    }
}
