using CasaDoCodigo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Controllers
{
    public class RequestController : Controller
    {
        private readonly IProductRepository productRepository;

        public RequestController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
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
