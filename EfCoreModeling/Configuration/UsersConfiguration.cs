using EfCoreModeling.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreModeling.Configuration
{
    class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(x => x.UserName)
                   .HasMaxLength(55)
                   .IsRequired();

            builder.Property(x => x.UserId)
                   .UseSqlServerIdentityColumn();

            builder.HasIndex(x => x.EmailId).IsUnique();

            builder.HasOne(x => x.Email)
                   .WithOne(x => x.User)
                   .HasForeignKey<User>(x => x.EmailId)
                   .HasPrincipalKey<Email>(x => x.EmailId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.RoleID)
                   .HasMaxLength(120);

            builder.HasOne(x => x.Role)
                   .WithMany(x => x.Users)
                   .HasForeignKey(x => x.RoleID)
                   .HasPrincipalKey(x => x.RoleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Message)
                   .WithOne(x => x.User)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Adrres)
                   .WithMany(x => x.User)
                   .HasForeignKey(x => x.AdrresId)
                   .HasPrincipalKey(x => x.AdrresId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
