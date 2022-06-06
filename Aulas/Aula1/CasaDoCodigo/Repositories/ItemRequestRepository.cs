using CasaDoCodigo.Models;

namespace CasaDoCodigo.Repositories
{
    public interface IItemRequestRepository
    {

    }

    public class ItemRequestRepository : BaseRepository<ItemRequest>, IItemRequestRepository
    {
        public ItemRequestRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
