using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.EF.Configurations
{
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> modelBuilder)
        {
            modelBuilder.ToTable("Dish"); 
            modelBuilder.HasKey(d => d.Id); 
            modelBuilder.Property(d => d.Name).IsRequired();
            modelBuilder.Property(d => d.Description).IsRequired();
            modelBuilder.Property(d => d.Price).IsRequired();
            modelBuilder.Property(d => d.Type)
               .HasConversion(
                   v => v.ToString(),
                   v => (Typology)Enum.Parse(typeof(Typology), v));


            modelBuilder.HasOne(d => d.Menu).WithMany(m => m.Dishes).HasForeignKey(m => m.Id);

        }
    }
}