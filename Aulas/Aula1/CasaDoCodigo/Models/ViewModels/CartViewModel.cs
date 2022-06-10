using System.Collections.Generic;
using System.Linq;

namespace CasaDoCodigo.Models.ViewModels
{
    public class CartViewModel
    {
        public CartViewModel(IList<ItemRequest> items)
        {
            Items = items;
        }

        public IList<ItemRequest> Items { get; }

        public decimal Total => Items.Sum(i => i.Quantity * i.UnitPrice);
    }
}
