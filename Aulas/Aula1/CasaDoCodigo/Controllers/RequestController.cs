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
        public IActionResult Summary()
        {
            Request request = requestRepository.GetRequest();
            return View(request);
        }

        [HttpPost]
        public void UpdateQuantity([FromBody]ItemRequest itemRequest)
        {
            itemRequestRepository.UpdateQuantity(itemRequest);
        }
    }
}
