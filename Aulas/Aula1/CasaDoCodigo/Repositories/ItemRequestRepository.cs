using CasaDoCodigo.Models;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public interface IItemRequestRepository
    {
        ItemRequest GetItemRequest(int itemRequestId);
    }

    public class ItemRequestRepository : BaseRepository<ItemRequest>, IItemRequestRepository
    {
        public ItemRequestRepository(ApplicationContext context) : base(context)
        {
        }

        public ItemRequest GetItemRequest(int itemRequestId)
        {
            return DbSet.Where(ip => ip.Id == itemRequestId)
                .SingleOrDefault();
        }
    }
}
