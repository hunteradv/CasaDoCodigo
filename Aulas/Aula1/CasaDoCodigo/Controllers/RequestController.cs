using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Controllers
{
    public class RequestController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IRequestRepository requestRepository;

        public RequestController(IProductRepository productRepository, IRequestRepository requestRepository)
        {
            this.productRepository = productRepository;
            this.requestRepository = requestRepository;
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

            Request request = requestRepository.GetRequest();
            return View(request.Items);
        }
        public IActionResult Carousel()
        {          
            return View(productRepository.GetProducts());
        }
        public IActionResult Summary()
        {
            return View();
        }
    }
}
