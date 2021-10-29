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
    public class MenuConfiguration : IEntityTypeConfiguration<Menù>
    {
        public void Configure(EntityTypeBuilder<Menù> modelBuilder)
        {
            modelBuilder.ToTable("Menù");
            modelBuilder.HasKey(m => m.Id);
            modelBuilder.Property(m => m.Name).IsRequired();


            modelBuilder.HasMany(m => m.Dishes).WithOne(d => d.Menu).HasForeignKey(d => d.IdMenu);

          
        }
    }
}