using Bogus;
using Cashly.Domain.Entities;
using Cashly.Domain.Enums;
using Cashly.Domain.Exceptions;
using Cashly.TestDataBuilder.DomainDataBuilder.Entities;
using Cashly.TestDataBuilder.DomainDataBuilder.ValueObjects;
using Shouldly;

namespace Cashly.Domain.Tests.Entities.CategoryTests;
public class CategoryUnitTest
{
    [Fact(DisplayName = "Create category with valid parameters result object valid state")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => CategoryBuilder.BuildValidCategory();

        action.ShouldNotThrow();
    }

    [Fact(DisplayName = "Create category with invalid id result DomainExceptionValidation")] 
    public void CreateCategory_WithInvalidId_ResultDomainExceptionValidation()
    {
        Action action = () => CategoryBuilder.BuildInvalidCategory();

        action.ShouldThrow<DomainExceptionValidation>().Message.ShouldBe("Invalid Id value");
    }

    [Fact(DisplayName = "Create category and add valid transaction")]
    public void CreateCategory_AddTransactionWithValidValues_ResultValidObjectState()
    {
        // ARRANGE
        var faker = new Faker();
        var category = CategoryBuilder.BuildValidCategory();
        var transactionCategory = category;

        var transaction = new Transaction(
            id: faker.Random.Int(0, 100),
            amount: CashBuilder.BuildValidCash(),
            date: faker.Date.Soon(), 
            description: faker.Commerce.ProductDescription(), 
            type: faker.PickRandom<TransactionType>(), 
            category: transactionCategory, 
            cashflow: CashflowBuilder.BuildValidCashflow()
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
        var category = CategoryBuilder.BuildValidCategory();
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
        var category = CategoryBuilder.BuildValidCategory();
        var user = UserBuilder.BuildValidUser();
        var cashflow = CashflowBuilder.BuildValidCashflow();
        var transaction = TransactionBuilder.BuildValidTransaction();

        // ACT
        Action action = () => category.AddTransaction(transaction);

        // ASSERT
        action.ShouldThrow<DomainExceptionValidation>().Message.ShouldBe("The transaction does not belong to this category");
    }
}
