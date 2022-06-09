using CasaDoCodigo.Models;

namespace CasaDoCodigo.Repositories
{
    public interface IItemRequestRepository
    {
        void UpdateQuantity(ItemRequest itemRequest);        
    }

    public class ItemRequestRepository : BaseRepository<ItemRequest>, IItemRequestRepository
    {
        public ItemRequestRepository(ApplicationContext context) : base(context)
        {
        }

        public void UpdateQuantity(ItemRequest itemRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}
