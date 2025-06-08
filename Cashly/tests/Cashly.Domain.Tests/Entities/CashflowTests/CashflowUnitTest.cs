using Bogus;
using Cashly.Domain.Entities;
using Cashly.Domain.Enums;
using Cashly.Domain.Exceptions;
using Cashly.Domain.ValueObjects;
using Cashly.TestDataBuilder.DomainDataBuilder.Entities;
using Cashly.TestDataBuilder.DomainDataBuilder.ValueObjects;
using Shouldly;

namespace Cashly.Domain.Tests.Entities.CashflowTests;
public class CashflowUnitTest
{
    [Fact(DisplayName = "Create Cashflow with valid parameters result object valid state")]
    public void CreateCashflow_WithValidParameters_ResultObjectValidState()
    {
        // ARRANGE
        var idUser = 12;
        var name = new Name("Paula Andrade");
        var email = new Email("pandrade@gmail.com");
        var passwordHash = "sTTrINg22PHshC";
        var user = new User(idUser, name, email, passwordHash);
        var idCashflow = 1;

        // ACT
        Action action = () => new Cashflow(idCashflow, user);

        // ASSERT
        action.ShouldNotThrow();
    }

    [Fact(DisplayName = "Create cashflow with valid transaction CashflowStatus should be red")]
    public void CreateCashflow_WithValidTransaction_CashflowStatusShouldBeRed()
    {
        // ARRANGE
        var cashflow = CashflowBuilder.BuildValidCashflow();
        var transaction = TransactionBuilder.BuildValidExpenseTransaction();

        // ACT
        cashflow.AddTransaction(transaction);
        cashflow.SetCashflowStatus();

        // ASSERT
        cashflow.Status.ShouldBe(CashflowStatus.red);

    }

    [Fact(DisplayName = "Create cashflow with valid transaction CashflowStatus should be green")]
    public void CreateCashflow_WithValidTransactions_CashflowStatusShouldBeGreen()
    {
        // ARRANGE
        var cashflow = CashflowBuilder.BuildValidCashflow();
        var transaction = TransactionBuilder.BuildValidIncomeTransaction();


        // ACT
        cashflow.AddTransaction(transaction);

        // ASSERT
        cashflow.Status.ShouldBe(CashflowStatus.green);

    }

    [Fact(DisplayName = "Removing transaction with valid parameters Should not throw")]
    public void RemovingTransaction_WithValidParameters_ShouldNotThrow()
    {
        // ARRANGE
        var faker = new Faker();
        var cashflow = CashflowBuilder.BuildValidCashflow();

        var transaction = new Transaction(
            id: faker.Random.Int(1, 100),
            amount: CashBuilder.BuildValidCash(),
            date: faker.Date.Soon(),
            description: faker.Commerce.ProductDescription(),
            type: faker.PickRandom<TransactionType>(),
            category: CategoryBuilder.BuildValidCategory(),
            cashflow: cashflow
            );

        cashflow.AddTransaction(transaction);


        // ACT
        Action action = () => cashflow.RemoveTransaction(transaction);

        // ASSERT
        action.ShouldNotThrow();
        cashflow.Transactions.Count().ShouldBeEquivalentTo(0);

    }

    [Fact(DisplayName = "Removing transaction with invalid parameters result ArgumentException")]
    public void RemovingTransaction_WithInvalidParameters_ResultArgumentException()
    {
        // ARRANGE
        var faker = new Faker();
        var cashflow = CashflowBuilder.BuildValidCashflow();
        var transaction = new Transaction(
            id: faker.Random.Int(1, 100),
            amount: CashBuilder.BuildValidCash(),
            date: faker.Date.Soon(),
            description: faker.Commerce.ProductDescription(),
            type: faker.PickRandom<TransactionType>(),
            category: CategoryBuilder.BuildValidCategory(),
            cashflow: cashflow
            );


        // ACT
        Action action = () => cashflow.RemoveTransaction(transaction);

        // ASSERT
        action.ShouldThrow<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Removing transaction with valid parameters CurrentBalance Should be zero")]
    public void RemovingTransaction_WithValidParameters_CurrentBalanceShouldBeZero()
    {
        // ARRANGE
        var cashflow = CashflowBuilder.BuildValidCashflow();
        var transaction = TransactionBuilder.BuildValidTransaction();
        cashflow.AddTransaction(transaction);

        // ACT
        cashflow.RemoveTransaction(transaction);

        // ASSERT
        cashflow.CurrentBalance.ShouldBe(0);
        cashflow.Transactions.Count().ShouldBeEquivalentTo(0);

    }

    [Fact(DisplayName = "Add transaction with invalid parameters result ArgumentException")]
    public void AddTransaction_WithInvalidParameters_ResultArgumentNullException()
    {
        // ARRANGE
        Transaction transaction = null;
        var cashflow = CashflowBuilder.BuildValidCashflow();

        // ACT
        Action action = () => cashflow.AddTransaction(transaction);

        // ASSERT
        action.ShouldThrow<DomainExceptionValidation>();

    }

    [Fact(DisplayName = "Add Transaction with valid Parameters result CurrentBalance different than zero")]
    public void AddTransaction_WithValidParameters_ResultCurrentBalanceDifferentThanZero()
    {
        // ARRANGE
        var faker = new Faker();
        var cashflow = CashflowBuilder.BuildValidCashflow();
        var transaction = new Transaction(
            id: faker.Random.Int(1, 100),
            amount: CashBuilder.BuildValidCash(),
            date: faker.Date.Soon(),
            description: faker.Commerce.ProductDescription(),
            type: faker.PickRandom<TransactionType>(),
            category: CategoryBuilder.BuildValidCategory(),
            cashflow: cashflow
            );

        // ACT
        cashflow.AddTransaction(transaction);

        // ASSERT
        cashflow.Transactions.Count().ShouldBeGreaterThan(0);
        cashflow.CurrentBalance.ShouldNotBe(0);
    }

}
