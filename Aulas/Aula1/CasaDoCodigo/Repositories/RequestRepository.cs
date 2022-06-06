using CasaDoCodigo.Models;

namespace CasaDoCodigo.Repositories
{
    public interface IRequestRepository
    { 

    }

    public class RequestRepository : BaseRepository<Request>, IRequestRepository
    {
        public RequestRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
