using InventoryManager.Client.Responses;
using InventoryManager.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.BLL.Services
{
    public class PalletService
    {
        private readonly InventoryManagerContext _inventoryManagerContext;

        public PalletService(InventoryManagerContext inventoryManagerContext)
        {
            _inventoryManagerContext = inventoryManagerContext;
        }

        public GetPalletResponse GetPallet(int palletId)
        {
            var pallet = _inventoryManagerContext.Pallets
                .Include(x => x.Size)
                .SingleOrDefault(x => x.Id == palletId);

            if(pallet == null)
            {
                throw new ArgumentException($"Pallet: {palletId} does not exist");
            }

            TakeDownPallet(pallet);

            return new GetPalletResponse { 
                Size = new SizeDto
                {
                    Height = pallet.Size.Height,
                    Length = pallet.Size.Length,
                    Width = pallet.Size.Width
                },
                Weight = pallet.Weight
            };

        }

        private void TakeDownPallet(Pallet pallet)
        {
            pallet.IsPlaced = false;
            _inventoryManagerContext.Update(pallet);
            _inventoryManagerContext.SaveChanges();
        }
    }
}
