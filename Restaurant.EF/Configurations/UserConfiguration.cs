using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.EF.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder.ToTable("User");
            modelBuilder.HasKey(u => u.Id);
            modelBuilder.Property(u => u.Name).IsRequired();
            modelBuilder.Property(u => u.Username).IsRequired();
            modelBuilder.Property(u => u.Password).IsRequired();
            modelBuilder.Property(u => u._Role).IsRequired();
        }
    }
}