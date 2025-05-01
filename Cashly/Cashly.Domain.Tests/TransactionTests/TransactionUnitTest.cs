using Cashly.Domain.Entities;
using Cashly.Domain.Enums;
using Cashly.Domain.Exceptions;
using Cashly.Domain.ValueObjects;
using Shouldly;

namespace Cashly.Domain.Tests.TransactionTests
{
    public class TransactionUnitTest
    {
        [Fact(DisplayName = "Create Transaction with valid parameters")]
        public void CreateTransaction_WithValidParameters_ResultObjectValidState()
        {
            // ARRANGE
            var userId = 1;
            var name = new Name("Rafael");
            var email = new Email("rafael@gmail.com");
            var passwordHash = "stringqualquer";
            var user = new User(userId, name, email, passwordHash);

            var cashflowId = 1;
            var cashflow = new Cashflow(cashflowId, user);

            var categoryId = 1;
            var categoryName = new Name("Academia");
            var description = "Valores destinados a academia";
            var category = new Category(categoryId, categoryName, description);

            // ACT
            Action action = () => new Transaction(3, new Cash(150.00m), DateTime.Now, "Academia", TransactionType.Expense, category, cashflow);

            // ASSERT
            action.ShouldNotThrow();

        }

        [Fact(DisplayName = "Complete a scheduled transaction result object valid state ")]
        public void CompleteScheduledTransaction_WithValidParameters_ResultObjectValidState()
        {
            // ARRANGE
            var userId = 1;
            var name = new Name("Rafael");
            var email = new Email("rafael@gmail.com");
            var passwordHash = "stringqualquer";
            var user = new User(userId, name, email, passwordHash);

            var cashflowId = 1;
            var cashflow = new Cashflow(cashflowId, user);

            var categoryId = 1;
            var categoryName = new Name("Academia");
            var description = "Saúde";
            var category = new Category(categoryId, categoryName, description);

            var transactionId = 1;
            var amount = new Cash(70.00m);
            var date = DateTime.Now.AddDays(30);
            var transactionDescription = "Academia";
            var type = TransactionType.Expense;
            var transaction = new Transaction(transactionId, amount, date, transactionDescription, type, category, cashflow);

            // ACT
            transaction.MarkAsCompleted();

            // ASSERT
            transaction.Status.ShouldBe(TransactionStatus.Completed);


        }

        [Fact(DisplayName = "Cancel a scheduled transaction result object valid state ")]
        public void CancelScheduledTransaction_WithValidParameters_ResultObjectValidState()
        {
            // ARRANGE
            var userId = 1;
            var name = new Name("Rafael");
            var email = new Email("rafael@gmail.com");
            var passwordHash = "stringqualquer";
            var user = new User(userId, name, email, passwordHash);

            var cashflowId = 1;
            var cashflow = new Cashflow(cashflowId, user);

            var categoryId = 1;
            var categoryName = new Name("Academia");
            var description = "Saúde";
            var category = new Category(categoryId, categoryName, description);

            var transactionId = 1;
            var amount = new Cash(70.00m);
            var date = DateTime.Now.AddDays(30);
            var transactionDescription = "Academia";
            var type = TransactionType.Expense;
            var transaction = new Transaction(transactionId, amount, date, transactionDescription, type, category, cashflow);

            // ACT
            transaction.MarkAsCanceled();

            // ASSERT
            transaction.Status.ShouldBe(TransactionStatus.Canceled);

        }

        [Fact(DisplayName = "Cancel a completed transaction result DomainExceptionValidation")]
        public void Cancel_CompletedTransaction_DomainExceptionValidation()
        {
            // ARRANGE
            var userId = 1;
            var name = new Name("Angela");
            var email = new Email("Angela@gmail.com");
            var passwordHash = "stringqualquer";
            var user = new User(userId, name, email, passwordHash);

            var cashflowId = 1;
            var cashflow = new Cashflow(cashflowId, user);

            var categoryId = 1;
            var categoryName = new Name("Viagem");
            var description = "Reembolso da companhia aerea";
            var category = new Category(categoryId, categoryName, description);

            var transactionId = 1;
            var amount = new Cash(500.00m);
            var date = new DateTime(2025-05-01);
            var descriptionTransaction = "";
            var type = TransactionType.Income;
            var transaction = new Transaction(transactionId, amount, date, descriptionTransaction, type, category, cashflow);
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
            var userId = 1;
            var name = new Name("Patricia");
            var email = new Email("patty@gmail.com");
            var passwordHash = "stringqualquer";
            var user = new User(userId, name, email, passwordHash);

            var cashflowId = 1;
            var cashflow = new Cashflow(cashflowId, user);

            var categoryId = 1;
            var categoryName = new Name("Venda");
            var description = "Vendas de doces na loja";
            var category = new Category(categoryId, categoryName, description);

            var transactionId = 1;
            var amount = new Cash(23.00m);
            var date = new DateTime(2025 - 05 - 01);
            var descriptionTransaction = "Flávia pegou mais 23 brigadeiros de emergencia";
            var type = TransactionType.Income;
            var transaction = new Transaction(transactionId, amount, date, descriptionTransaction, type, category, cashflow);
            transaction.MarkAsCanceled();

            // ACT
            Action action = () => transaction.MarkAsCompleted();


            // ASSERT
            action.ShouldThrow<DomainExceptionValidation>().Message.ShouldBe("Cannot complete a canceled transaction");
        }
    }
}
