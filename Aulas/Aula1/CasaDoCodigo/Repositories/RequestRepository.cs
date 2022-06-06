using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Http;

namespace CasaDoCodigo.Repositories
{
    public interface IRequestRepository
    { 

    }

    public class RequestRepository : BaseRepository<Request>, IRequestRepository
    {
        private readonly IHttpContextAccessor contextAccessor;

        public RequestRepository(ApplicationContext context,
            IHttpContextAccessor contextAccessor) : base(context)
        {
            this.contextAccessor = contextAccessor;
        }

        private int? GetRequestId()
        {
            return contextAccessor.HttpContext.Session.GetInt32("requestId");
        }

        private void SetRequestId(int requestId)
        {
            contextAccessor.HttpContext.Session.SetInt32("requestId", requestId);
        }
    }
}
