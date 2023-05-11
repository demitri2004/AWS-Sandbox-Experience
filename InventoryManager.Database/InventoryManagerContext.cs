using Microsoft.EntityFrameworkCore;
using InventoryManager.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Database
{
    public class InventoryManagerContext : DbContext
    {
        public virtual DbSet<Pallet> Pallets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseMySQL("server=inventorymanagerresoources-database-pp3u8n5ppeqe.cnqozcbfsyxv.us-east-2.rds.amazonaws.com; user=; password=; database=InventoryManagerDB");
            base.OnConfiguring(optionsBuilder);
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Publisher>(entity =>
        //    {
        //        entity.HasKey(e => e.ID);
        //        entity.Property(e => e.Name).IsRequired();
        //    });

        //    modelBuilder.Entity<Book>(entity =>
        //    {
        //        entity.HasKey(e => e.ISBN);
        //        entity.Property(e => e.Title).IsRequired();
        //        entity.HasOne(d => d.Publisher)
        //          .WithMany(p => p.Books);
        //    });
        //}
    }
}
