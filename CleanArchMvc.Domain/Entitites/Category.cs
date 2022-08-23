using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entitites
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        public ICollection<Product> Products { get; } 

        public Category(string name)
        {
            ValidateDomain(name);
            Name = name;
        }

        public Category(int id, string name)
        {
            ValidateDomain(name, id);
            Id = id;
            Name = name;
        }


        public void Update(string name)
        {
            ValidateDomain(name);
            Name = name;
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required.");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name. It has to have at least 3 characters.");
        }

        private void ValidateDomain(string name, int id )
        {
            ValidateDomain(name);

            DomainExceptionValidation.When(id < 0,
                "Invalid ID. ID has to be greater than or equal 0.");
        }
    }
}
