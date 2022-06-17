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
        [MinLength(5, ErrorMessage = "Nome deve ter no m�nimo 5 caracteres")]
        [MaxLength(50, ErrorMessage = "Nome deve ter no m�ximo 50 caracteres")]
        [Required(ErrorMessage = "Nome � obrigat�rio")]
        public string Name { get; set; } = "";
        [Required(ErrorMessage = "Email � obrigat�rio")]
        public string Email { get; set; } = "";
        [Required(ErrorMessage = "Telefone � obrigat�rio")]
        public string Telephone { get; set; } = "";
        [Required(ErrorMessage = "Endere�o � obrigat�rio")]
        public string Address { get; set; } = "";
        [Required(ErrorMessage = "Complemento � obrigat�rio")]
        public string Complement { get; set; } = "";
        [Required(ErrorMessage = "Bairro � obrigat�rio")]
        public string District { get; set; } = "";
        [Required(ErrorMessage = "Cidade � obrigat�ria")]
        public string City { get; set; } = "";
        [Required(ErrorMessage = "UF � obrigat�rio")]
        public string UF { get; set; } = "";
        [Required(ErrorMessage = "CEP � obrigat�rio")]
        public string CEP { get; set; } = "";

        internal void Update(Register newRegister)
        {
            this.District = newRegister.District;
            this.CEP = newRegister.CEP;
            this.Complement = newRegister.Complement;
            this.Email = newRegister.Email;
            this.Address = newRegister.Address;
            this.City = newRegister.City;
            this.Name = newRegister.Name;
            this.Telephone = newRegister.Telephone;
            this.UF = newRegister.UF;
        }
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
