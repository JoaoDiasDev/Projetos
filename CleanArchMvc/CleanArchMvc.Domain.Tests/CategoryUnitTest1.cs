using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    /// <summary>
    /// The category unit test1.
    /// </summary>
    public class CategoryUnitTest1
    {
        /// <summary>
        /// Creates the category_ with valid parameters_ result object valid state.
        /// </summary>
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name ");
            action.Should()
                 .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        /// <summary>
        /// Creates the category_ negative id value_ domain exception invalid id.
        /// </summary>
        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name ");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid Id value.");
        }

        /// <summary>
        /// Creates the category_ short name value_ domain exception short name.
        /// </summary>
        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                   .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        /// <summary>
        /// Creates the category_ missing name value_ domain exception required name.
        /// </summary>
        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name.Name is required");
        }

        /// <summary>
        /// Creates the category_ with null name value_ domain exception invalid name.
        /// </summary>
        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
    }
}
