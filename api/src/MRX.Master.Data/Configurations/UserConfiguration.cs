using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRX.Master.Domain.Models;
using System;

namespace MRX.Master.Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.Active).IsRequired()
                .HasDefaultValue(true);
            builder.Property(b => b.Deleted)
                .HasDefaultValue(false);
            builder.Property(b => b.CreatedDate)
                .HasDefaultValue(DateTime.Now);
            builder.Property(b => b.UserName).IsRequired();
            builder.HasIndex(b => b.UserName).IsUnique();
            builder.Property(b => b.Email).IsRequired();
            builder.HasIndex(b => b.Email).IsUnique();
            builder.Property(b => b.FirstName).IsRequired();
            builder.Property(b => b.LastName).IsRequired();
            builder.Property(b => b.MobileNumber);
            builder.Property(b => b.NIC);
            builder.HasMany(u => u.UserChoices)
                .WithOne(uc => uc.User);
        }
    }
}
