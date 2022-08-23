using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entitites
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }

        public string Description { get; private set;}

        public decimal Price { get; private set; }

        public int Stock { get; private set; }

        public string Image { get; private set; }

        // Foreign Key
        public int CategoryId { get; set; }

        public Category Category { get; set; }


        // Product
        public Product(string name, string description, decimal price, int stock, string image)
        {

            ValidateDomain(name, description, price, stock, image);
            AssignValues(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {

            ValidateDomain(id, name, description, price, stock, image);
            AssignValues(id, name, description, price, stock, image);

        }
        // End of Product


        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {

            ValidateDomain(name, description, price, stock, image, categoryId);
            AssignValues(name, description, price, stock, image, categoryId);
        }


        // AssignValues
        private void AssignValues(string name, string description, decimal price, int stock, string image)
        {
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        private void AssignValues(int id, string name, string description, decimal price, int stock, string image)
        {
            AssignValues(name, description, price, stock, image);
            Id = id;
        }

        private void AssignValues(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            AssignValues(name, description, price, stock, image);
            CategoryId = categoryId;
        }
        // End of AssignValues


        // ValidateDomain
        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
               "Invalid name. Name is required.");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name. It has to have at least 3 characters.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description. Description is required.");

            DomainExceptionValidation.When(description.Length < 5,
                "Invalid description. It has to have at least 5 characters.");

            DomainExceptionValidation.When(price < 0, "Invalid price value.");

            DomainExceptionValidation.When(stock < 0, "Invalid stock value.");

            DomainExceptionValidation.When(image?.Length > 250, "Invalid image name. It has to have less than 250 characters.");
        }

        private void ValidateDomain(int id, string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);

            DomainExceptionValidation.When(id < 0,
                "Invalid ID. ID has to be greater than or equal 0.");
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);

            DomainExceptionValidation.When(categoryId < 0,
                 "Invalid Category ID. Category ID has to be greater than or equal 0.");
        }
        // End of ValidateDomain
    }
}
