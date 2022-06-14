using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using CasaDoCodigo.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CasaDoCodigo.Controllers
{
    public class RequestController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IRequestRepository requestRepository;
        private readonly IItemRequestRepository itemRequestRepository;

        public RequestController(IProductRepository productRepository, IRequestRepository requestRepository, IItemRequestRepository itemRequestRepository)
        {
            this.productRepository = productRepository;
            this.requestRepository = requestRepository;
            this.itemRequestRepository = itemRequestRepository;            
        }

        public IActionResult Register()
        {
            var request = requestRepository.GetRequest();

            if( request is null )
            {
                return RedirectToAction("Carousel");
            }

            return View();
        }
        public IActionResult Cart(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                requestRepository.AddItem(code);
            }

            List<ItemRequest> items = requestRepository.GetRequest().Items;
            CartViewModel cartViewModel = new CartViewModel(items);
            return base.View (cartViewModel);
        }
        public IActionResult Carousel()
        {          
            return View(productRepository.GetProducts());
        }

        [HttpPost]
        public IActionResult Summary(Register register)
        {
            
            return View( requestRepository.GetRequest() );
        }

        [HttpPost]
        public UpdateQuantityResponse UpdateQuantity([FromBody]ItemRequest itemRequest)
        {
            return requestRepository.UpdateQuantity(itemRequest);
        }
    }
}
