using CasaDoCodigo.Models;
using System.Collections.Generic;

namespace CasaDoCodigo.Repositories
{
    public interface IProductRepository
    {
        void SaveProducts(List<Book> books);
        IList<Product> GetProducts(); 
    }
}