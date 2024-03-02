using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        //expression-bodied member
        public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

        private IList<Product> _products  = new List<Product>();

        public Category(string name)
        {
            ValidateDomain(name);
            Name = name;
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            ValidateDomain(name);

            Id = id;
            Name = name;
        }

        public void Update(string name) 
        { 
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(
                string.IsNullOrEmpty(name),
                "Invalid name. Name is required"
            );

            DomainExceptionValidation.When(
                name.Length < 3,
                "Invalid name, to short, minimum 3 characteres"
            );
        }
    }
}
