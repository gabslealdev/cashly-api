using Bogus;
using Cashly.Domain.Entities;
using Cashly.Domain.Enums;
using Cashly.Domain.Exceptions;
using Cashly.TestDataBuilder.DomainDataBuilder.Entities;
using Cashly.TestDataBuilder.DomainDataBuilder.ValueObjects;
using Shouldly;

namespace Cashly.Domain.Tests.Entities.TransactionTests
{
    public class TransactionUnitTest
    {
        [Fact(DisplayName = "Create Transaction with valid parameters")]
        public void CreateTransaction_WithValidParameters_ResultObjectValidState()
        {
            // ACT
            Action action = () => TransactionBuilder.BuildValidTransaction();

            // ASSERT
            action.ShouldNotThrow();

        }

        [Fact(DisplayName = "Create transaction with null category result DomainExceptionValidation")]
        public void CreateTransaction_WithNullCategory_ResultDomainExceptionValidation()
        {
            var faker = new Faker();
            
            // ACT 
            Action action = () => new Transaction(
                id: faker.Random.Int(1, 100),
                amount: CashBuilder.BuildValidCash(),
                date: faker.Date.Soon(),
                description: faker.Commerce.ProductDescription(),
                type: faker.PickRandom<TransactionType>(),
                category: null,
                cashflow: CashflowBuilder.BuildValidCashflow()
                );

            // ASSERT
            action.ShouldThrow<DomainExceptionValidation>().Message.ShouldBe("Category cannot be null");

        }

        [Fact(DisplayName = "Create transaction with null cashflow result DomainExceptionValidation")]
        public void CreateTransaction_WithNullCashflow_ResultDomainExceptionValidation()
        {
            var faker = new Faker();

            // ACT 
            Action action = () => new Transaction(
                id: faker.Random.Int(1, 100),
                amount: CashBuilder.BuildValidCash(),
                date: faker.Date.Soon(),
                description: faker.Commerce.ProductDescription(),
                type: faker.PickRandom<TransactionType>(),
                category: CategoryBuilder.BuildInvalidCategory(),
                cashflow: null
                );

            // ASSERT
            action.ShouldThrow<DomainExceptionValidation>();

        }

        [Fact(DisplayName = "Complete a scheduled transaction result object valid state ")]
        public void CompleteScheduledTransaction_WithValidParameters_ResultObjectValidState()
        {
            // ARRANGE
            var transaction = TransactionBuilder.BuildValidIncomeTransaction();

            // ACT
            transaction.MarkAsCompleted();

            // ASSERT
            transaction.Status.ShouldBe(TransactionStatus.Completed);
        }

        [Fact(DisplayName = "Cancel a scheduled transaction result object valid state ")]
        public void CancelScheduledTransaction_WithValidParameters_ResultObjectValidState()
        {
            // ARRANGE
            var transaction = TransactionBuilder.BuildValidIncomeTransaction();

            // ACT
            transaction.MarkAsCanceled();

            // ASSERT
            transaction.Status.ShouldBe(TransactionStatus.Canceled);
        }

        [Fact(DisplayName = "Cancel a completed transaction result DomainExceptionValidation")]
        public void Cancel_CompletedTransaction_DomainExceptionValidation()
        {
            // ARRANGE
            var transaction = TransactionBuilder.BuildValidIncomeTransaction();
            transaction.MarkAsCompleted();

            // ACT
            Action action = () => transaction.MarkAsCanceled();


            // ASSERT
            action.ShouldThrow<DomainExceptionValidation>().Message.ShouldBe("Cannot cancel a completed transaction.");
        }

        [Fact(DisplayName = "Complete a canceled transaction result DomainExceptionValidation")]
        public void Complete_CanceledTransaction_DomainExceptionValidation()
        {
            // ARRANGE
            var transaction = TransactionBuilder.BuildValidIncomeTransaction();
            transaction.MarkAsCanceled();

            // ACT
            Action action = () => transaction.MarkAsCompleted();


            // ASSERT
            action.ShouldThrow<DomainExceptionValidation>().Message.ShouldBe("Cannot complete a canceled transaction");
        }
    }
}
