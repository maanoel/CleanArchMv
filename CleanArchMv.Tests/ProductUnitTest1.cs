using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMv.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState() 
        {
            Action action = () => new Product(1, "Litrão", "Do bom", 10, "", 10);

            action
                .Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Sabonete", "Protex", 1, "", 1000);

            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid id");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "sa", "Mesa", 10000, "", 1000);

            action.Should()
                  .Throw<DomainExceptionValidation>()
                  .WithMessage("Invalid name, too short, minimium 3 characteres");
        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Product(10000, "Computador", "I1000", 1,
                "IMAGEM TOOOOOOOOOOOOOOOOOOAAAAAAAAAAAAAAAAAAAAAAAAAAAAAOOAAAAAAAAAAAAATOOOOOOOOOOOOOOOOOOAAAAAAAAAAAAAAAAAAAAAAAAAAAAAOOAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAOOOOOOOOOOOOOOOOOOOAAAAAAAAATOOOOOOOOOOOOOOOOOOAAAAAAAAAAAAAAAAAAAAAAAAAAAAAOOAAAAAAAAAAAAATOOOOOOOOOOOOOOOOOOAAAAAAAAAAAAAAAAAAAAAAAAAAAAAOOAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAOOOOOOOOOOOOOOOOOOOAAAAAAAAAAAAAAAAAAAAAAAAAAOOOOO LONG", 0);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid image value");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Iphone 1000", "Iphone de última geração", 1, null, 0);

            action
                .Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Iphone 1000", "Iphone de última geração", 1, "", 0);

            action
                .Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(-5000)]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "Iphone 1000", "Iphone de última geração", 1, "", value);

            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }


        [Theory]
        [InlineData(-5)]
        [InlineData(-5000)]
        [InlineData(-5)]
        public void CreateProduct_InvalidPriceValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "Iphone 1000", "Iphone de última geração", value, "", 1);

            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid price value");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoNullReferenceException() 
        {
            Action action = () => new Product(1, "Iphone 100", "Iphone antigo", 100, null, 10);

            action
                .Should()
                .NotThrow<NullReferenceException>();
        }
    }
}
