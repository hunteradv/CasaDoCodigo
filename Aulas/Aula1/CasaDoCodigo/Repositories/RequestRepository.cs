using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public interface IRequestRepository
    {
        Request GetRequest();
        void AddItem(string code);
        UpdateQuantityResponse UpdateQuantity(ItemRequest itemRequest);
    }

    public class RequestRepository : BaseRepository<Request>, IRequestRepository
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IItemRequestRepository itemRequestRepository;

        public RequestRepository(ApplicationContext context,
            IHttpContextAccessor contextAccessor,
            IItemRequestRepository itemRequestRepository) : base(context)
        {
            this.contextAccessor = contextAccessor;
            this.itemRequestRepository = itemRequestRepository;
        }

        public void AddItem(string code)
        {
            var product = context.Set<Product>().Where(p => p.Code == code).SingleOrDefault();

            if (product == null)
            {
                throw new ArgumentException("Produto não encontrado");
            }

            var request = GetRequest();

            var itemRequest = context.Set<ItemRequest>().Where(i => i.Product.Code == code && i.Request.Id == request.Id).SingleOrDefault();

            if(itemRequest == null)
            {
                itemRequest = new ItemRequest(request, product, 1, product.Price);
                context.Set<ItemRequest>().Add(itemRequest);

                context.SaveChanges();
            }
        }

        public Request GetRequest()
        {
            var requestId = GetRequestId();
            var request = DbSet.Include(p => p.Items)
                    .ThenInclude(i => i.Product)
                .Where(p => p.Id == requestId)
                .SingleOrDefault();

            if(request == null)
            {
                request = new Request();
                DbSet.Add(request);
                context.SaveChanges();
                SetRequestId(request.Id);
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

        public UpdateQuantityResponse UpdateQuantity(ItemRequest itemRequest)
        {
            var itemRequestDB = itemRequestRepository.GetItemRequest(itemRequest.Id);

            if (itemRequestDB != null)
            {
                itemRequestDB.RefreshQuantity(itemRequest.Quantity);

                context.SaveChanges();

                var cartViewModel = new CartViewModel(GetRequest().Items);

                return new UpdateQuantityResponse(itemRequestDB, cartViewModel);
            }

            throw new ArgumentException("ItemRequest não encontrado");
        }
    }
}
