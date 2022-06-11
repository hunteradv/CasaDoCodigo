using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    [DataContract]
    public class BaseModel
    {
        [DataMember]
        public int Id { get; protected set; }
    }

    public class Product : BaseModel
    {
        public Product()
        {

        }

        [Required]
        public string Code { get; private set; }
        [Required]
        public string Name { get; private set; }
        [Required]
        public decimal Price { get; private set; }

        public Product(string code, string name, decimal price)
        {
            this.Code = code;
            this.Name = name;
            this.Price = price;
        }
    }

    public class Register : BaseModel
    {
        public Register()
        {
        }

        public virtual Request Request { get; set; }
        [Required]
        public string Name { get; set; } = "";
        [Required]
        public string Email { get; set; } = "";
        [Required]
        public string Telephone { get; set; } = "";
        [Required]
        public string Address { get; set; } = "";
        [Required]
        public string Complement { get; set; } = "";
        [Required]
        public string District { get; set; } = "";
        [Required]
        public string City { get; set; } = "";
        [Required]
        public string UF { get; set; } = "";
        [Required]
        public string CEP { get; set; } = "";
    }

    [DataContract]
    public class ItemRequest : BaseModel
    {
        [Required]
        [DataMember]
        public Request Request { get; private set; }
        [Required]
        [DataMember]
        public Product Product { get; private set; }
        [Required]
        [DataMember]
        public int Quantity { get; private set; }
        [Required]
        [DataMember]
        public decimal UnitPrice { get; private set; }
        [DataMember]
        public decimal Subtotal => Quantity * UnitPrice;

        public ItemRequest()
        {

        }

        public ItemRequest(Request request, Product product, int quantity, decimal unitPrice)
        {
            Request = request;
            Product = product;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        internal void RefreshQuantity(int quantity)
        {
            Quantity = quantity;
        }
    }

    public class Request : BaseModel
    {
        public Request()
        {
            Register = new Register();
        }

        public Request(Register register)
        {
            Register = register;
        }

        public List<ItemRequest> Items { get; private set; } = new List<ItemRequest>();
        [Required]
        public virtual Register Register { get; private set; }
    }
}
