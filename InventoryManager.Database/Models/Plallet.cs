using InventoryManager.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Database
{
    public class Pallet
    {
        public int Id { get; set; }
        public virtual Size Size { get; set; }
        public decimal Weight { get; set; }
        public bool IsPlaced { get; set; }
    }
}
