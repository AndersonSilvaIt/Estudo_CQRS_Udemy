using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMVC.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category with valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");

            // Ele passa se não lançar uma excessão do tipo DomainExceptionValidation.
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category with valid State")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id Value");
        }

        [Fact(DisplayName = "Create Category with valid State")]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create Category with valid State")]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredNAme()
        {
            Action action = () => new Category(1, "");

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name.Name is required");
        }

        [Fact(DisplayName = "Create Category with valid State")]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);

            action.Should().Throw<DomainExceptionValidation>();
        }
    }
}