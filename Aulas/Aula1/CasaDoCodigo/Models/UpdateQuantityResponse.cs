using CasaDoCodigo.Models.ViewModels;

namespace CasaDoCodigo.Models
{
    public class UpdateQuantityResponse
    {
        public UpdateQuantityResponse(ItemRequest itemRequest, CartViewModel cartViewModel)
        {
            ItemRequest = itemRequest;
            CartViewModel = cartViewModel;
        }

        public ItemRequest ItemRequest { get; }
        public CartViewModel CartViewModel { get; }
    }
}