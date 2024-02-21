using CleanArchMvc.Domain.Entities;
using FluentAssertions;

using CleanArchMvc.Domain.Validation;

namespace CleanArchMv.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create category with valid state")]
        public void CreateCategory_WithValidParameters_ResultObjectValidadState()
        {
            Action action = () => new Category(1, "Livros");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeValue_DomainExceptionInvalid()
        {
            Action action = () => new Category(-1, "Livros");

            action.
                Should().
                Throw<DomainExceptionValidation>().
                WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");

            action.
                Should().
                Throw<DomainExceptionValidation>().
                WithMessage("Invalid name, to short, minimum 3 characteres");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainEXceptionRequiredName()
        {
            Action action = () => new Category(1, "");

            action.
                Should().
                Throw<DomainExceptionValidation>().
                WithMessage("Invalid name. Name is required");
        }
    }
}
