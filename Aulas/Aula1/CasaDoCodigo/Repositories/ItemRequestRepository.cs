using CasaDoCodigo.Models;
using System.Linq;

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
            var itemRequestDB = DbSet.Where(ip => ip.Id == itemRequest.Id)
                .SingleOrDefault();

            if (itemRequestDB != null)
            {
                itemRequestDB.RefreshQuantity(itemRequest.Quantity);

                context.SaveChanges();
            }
        }
    }
}
