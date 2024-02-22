using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }


        public Product(int id, string name, string description, decimal price, string image, int stock)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id");
            
            id = Id;

            ValidateDomain(name, description, price, image, stock);
        }


        public Product(string name, string description, decimal price, string image, int stock)
        {
            ValidateDomain(name, description, price, image, stock);
        }

        public void Update (string name, string description, decimal price, string image, int stock, int categoryId)
        {
            ValidateDomain(name, description, price, image, stock);
        }


        private void ValidateDomain(string name, string description, decimal price, string image, int stock)
        { 
            DomainExceptionValidation.When(
                string.IsNullOrEmpty(name), "Invalid name. Name is requerides"
            );

            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimium 3 characteres");

            DomainExceptionValidation.When(
                string.IsNullOrEmpty(description), "Invalid description. Description is required."
            );

            DomainExceptionValidation.When(
                description.Length < 5, "Invalid description, too short, minium 5 characteres."
            ) ;

            DomainExceptionValidation.When(price < 0, "Invalid price value");

            DomainExceptionValidation.When(stock < 0, "Invalid stock value");

            DomainExceptionValidation.When(image?.Length > 250, "Invalid image value");


            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public int CategoryId { get; set; }
        public  Category Category { get; set; }
    }
}
