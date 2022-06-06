using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public interface IRequestRepository
    {
        Request GetRequest();
    }

    public class RequestRepository : BaseRepository<Request>, IRequestRepository
    {
        private readonly IHttpContextAccessor contextAccessor;

        public RequestRepository(ApplicationContext context,
            IHttpContextAccessor contextAccessor) : base(context)
        {
            this.contextAccessor = contextAccessor;
        }

        public Request GetRequest()
        {
            var requestId = GetRequestId();
            var request = DbSet.Where(p => p.Id == requestId).SingleOrDefault();

            if(request == null)
            {
                request = new Request();
                DbSet.Add(request);
                context.SaveChanges();
            }

            return request;
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
