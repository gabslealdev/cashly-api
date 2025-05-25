using Cashly.Domain.ValueObjects;
using Cashly.Domain.Entities;
using Shouldly;
using Cashly.Domain.Exceptions;
using Cashly.Domain.Enums;
using Bogus;
using Cashly.TestFixtures.Fixtures.Entities;
using Cashly.TestFixtures.Fixtures.ValueObjects;

namespace Cashly.Domain.Tests.Entities.CategoryTests
{
    public class CategoryUnitTest
    {
        [Fact(DisplayName = "Create category with valid parameters result object valid state")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => CategoryFixture.CreateValidCategory();

            action.ShouldNotThrow();
        }

        [Fact(DisplayName = "Create category with invalid id result DomainExceptionValidation")] 
        public void CreateCategory_WithInvalidId_ResultDomainExceptionValidation()
        {
            Action action = () => CategoryFixture.CreateInvalidCategory();

            action.ShouldThrow<DomainExceptionValidation>().Message.ShouldBe("Invalid Id value");
        }

        [Fact(DisplayName = "Create category and add valid transaction")]
        public void CreateCategory_AddTransactionWithValidValues_ResultValidObjectState()
        {
            // ARRANGE
            var faker = new Faker();
            var category = CategoryFixture.CreateValidCategory();
            var transactionCategory = category;

            var transaction = new Transaction(
                id: faker.Random.Int(0, 100),
                amount: CashFixture.CreateValidCash(),
                date: faker.Date.Soon(), 
                description: faker.Commerce.ProductDescription(), 
                type: faker.PickRandom<TransactionType>(), 
                category: transactionCategory, 
                cashflow: CashflowFixture.CashflowValid()
                );

            // ACT
            Action action = () => category.AddTransaction(transaction);

            // ASSERT
            action.ShouldNotThrow();
        }

        [Fact(DisplayName = "Create a category and add null transaction")]
        public void CreateCategory_AddNullTransaction_DomainExceptionValidation()
        {
            // ARRANGE
            var category = CategoryFixture.CreateValidCategory();
            Transaction transaction = null;

            // ACT 
            Action action = () => category.AddTransaction(transaction);

            // ASSERT
            action.ShouldThrow<DomainExceptionValidation>().Message.ShouldBe("Transaction cannot be null");
        }

        [Fact(DisplayName = "Create Category and add transaction not beloging to this one")]
        public void CreateCategory_AddTransactionNotBelogingToThisOne_DomainExceptionValidation()
        {
            // ARRANGE
            var category = CategoryFixture.CreateValidCategory();
            var user = UserFixture.CreateValidUser();
            var cashflow = CashflowFixture.CashflowValid();
            var transaction = TransactionFixture.TransactionValid();

            // ACT
            Action action = () => category.AddTransaction(transaction);

            // ASSERT
            action.ShouldThrow<DomainExceptionValidation>().Message.ShouldBe("The transaction does not belong to this category");
        }
    }
}
