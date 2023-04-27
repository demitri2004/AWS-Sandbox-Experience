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
        public virtual DbSet<Pallet>? Pallets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            var connectionString = "server=inventorymanagerresoources-database-pp3u8n5ppeqe.cnqozcbfsyxv.us-east-2.rds.amazonaws.com; user=yourusername; password=youruserpassword; database=InventoryManagerDB";

            var serverVersion = new MySqlServerVersion(new Version(10, 4, 27));

            optionsBuilder.UseMySql(connectionString, serverVersion);
            base.OnConfiguring(optionsBuilder);
        }
       
    }
}
