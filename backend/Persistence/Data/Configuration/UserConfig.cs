using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(u => u.IdUser);
            builder.Property(u => u.IdUser)
            .UseMySqlIdentityColumn()
            .ValueGeneratedOnAdd();

            builder.Property(u => u.Username)
                .HasColumnName("Username")
                .HasColumnType("varchar")
                .HasMaxLength(50);


            builder.Property(u => u.Password)
                .HasColumnName("Password")
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.Property(u => u.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);
        }
    }
}