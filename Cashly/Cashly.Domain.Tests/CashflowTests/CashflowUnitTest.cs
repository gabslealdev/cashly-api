 using Cashly.Domain.Entities;
using Cashly.Domain.Enums;
using Cashly.Domain.ValueObjects;
using Shouldly;

namespace Cashly.Domain.Tests.CashflowTests
{
    public class CashflowUnitTest
    {
        [Fact(DisplayName = "Create Cashflow with valid state")]
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

        [Fact(DisplayName = "Create cashflow to testing UpdatedAt property")]
        public void CreateCashflow_ToTestingUpdatedAtProperty()
        {
            // ARRANGE
            var categoryId = 8;
            var categoryName = new Name("Educação");
            var descriptionCategory = "Valores destinados a cursos e meetups";
            var category = new Category(categoryId, categoryName, descriptionCategory);

            var idUser = 12;
            var userName = new Name("Paula Andrade");
            var email = new Email("pandrade@gmail.com");
            var passwordHash = "sTTrINg22PHshC";
            var user = new User(idUser, categoryName, email, passwordHash);

            var idCashflow = 1;
            var cashflow = new Cashflow(idCashflow, user);


            // ACT
            var idTransaction = 3;
            var amount = new Cash((decimal)80.00);
            var date = DateTime.Now;
            var descriptionTransaction = "Mensalidade da academia";
            var type = TransactionType.Expense;
            var transaction = new Transaction(idTransaction, amount, date, descriptionTransaction, type, category, cashflow);
            var now = DateTime.UtcNow;
            cashflow.AddTransaction(transaction);
            

            // ASSERT
            cashflow.UpdatedAt.ShouldBeInRange(now, cashflow.UpdatedAt.AddSeconds(1));

        }

        [Fact(DisplayName = "Create a cashflow with a null user should throw ArgumentNullException")]
        public void CreateCashflow_WithNull_ArgumentNullException()
        {
;            // ACT
            Action action = () => new Cashflow(id: 4, user: null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact (DisplayName = "Create cashflow with valid transaction CashflowStatus should be red")]
        public void CreateCashflow_WithValidTransaction_CashflowStatusShouldBeRed()
        {
            // ARRANGE
            var categoryId = 8;
            var categoryName = new Name("Educação");
            var descriptionCategory = "Valores destinados a cursos e meetups";
            var category = new Category(categoryId, categoryName, descriptionCategory);

            var idUser = 12;
            var userName = new Name("Paula Andrade");
            var email = new Email("pandrade@gmail.com");
            var passwordHash = "sTTrINg22PHshC";
            var user = new User(idUser, categoryName, email, passwordHash);

            var idCashflow = 1;
            var cashflow = new Cashflow(idCashflow, user);


            // ACT
            var idTransaction = 3;
            var amount = new Cash((decimal)80.00);
            var date = DateTime.Now;
            var descriptionTransaction = "Mensalidade da academia";
            var type = TransactionType.Expense;
            var transaction = new Transaction(idTransaction, amount, date, descriptionTransaction, type, category, cashflow);
            cashflow.AddTransaction(transaction);
            cashflow.SetCashflowStatus();

            // ASSERT
            cashflow.Status.ShouldBe(CashflowStatus.red);

        }

        [Fact(DisplayName = "Create cashflow with valid transaction CashflowStatus should be green")]
        public void CreateCashflow_WithValidTransactions_CashflowStatusShouldBeGreen()
        {
            // ARRANGE
            var categoryId = 8;
            var categoryName = new Name("Educação");
            var descriptionCategory = "Valores destinados a cursos e meetups";
            var category = new Category(categoryId, categoryName, descriptionCategory);

            var idUser = 12;
            var userName = new Name("Paula Andrade");
            var email = new Email("pandrade@gmail.com");
            var passwordHash = "sTTrINg22PHshC";
            var user = new User(idUser, categoryName, email, passwordHash);

            var idCashflow = 1;
            var cashflow = new Cashflow(idCashflow, user);


            // ACT
            var idTransaction = 3;
            var amount = new Cash((decimal)2000.00);
            var date = DateTime.Now;
            var descriptionTransaction = "Venda de notebook";
            var type = TransactionType.Income;
            var transaction = new Transaction(idTransaction, amount, date, descriptionTransaction, type, category, cashflow);
            cashflow.AddTransaction(transaction);

            // ASSERT
            cashflow.Status.ShouldBe(CashflowStatus.green);

        }

        [Fact(DisplayName = "Create cashflow with valid transaction to test CurrentBalance")]
        public void CreateCashflow_WithValidTransactionToTestingCurrenctBalance()
        {
            // ARRANGE
            var categoryId = 8;
            var categoryName = new Name("Educação");
            var descriptionCategory = "Valores destinados a cursos e meetups";
            var category = new Category(categoryId, categoryName, descriptionCategory);

            var idUser = 12;
            var userName = new Name("Paula Andrade");
            var email = new Email("pandrade@gmail.com");
            var passwordHash = "sTTrINg22PHshC";
            var user = new User(idUser, categoryName, email, passwordHash);

            var idCashflow = 1;
            var cashflow = new Cashflow(idCashflow, user);


            // ACT
            var idTransactionA = 3;
            var amountA = new Cash((decimal)3000.00);
            var dateA = DateTime.Now;
            var descriptionTransactionA = "Venda de notebook";
            var typeA = TransactionType.Income;
            var transactionA = new Transaction(idTransactionA, amountA, dateA, descriptionTransactionA, typeA, category, cashflow);
            cashflow.AddTransaction(transactionA);

            var idTransaction = 3;
            var amount = new Cash((decimal)1000.00);
            var date = DateTime.Now;
            var descriptionTransaction = "Mensalidade da academia";
            var type = TransactionType.Expense;
            var transaction = new Transaction(idTransaction, amount, date, descriptionTransaction, type, category, cashflow);
            cashflow.AddTransaction(transaction);

            // ASSERT
            cashflow.CurrentBalance.Equals(2000).ShouldBe(true);
        }

        [Fact(DisplayName = "Removing transaction with valid parameters Should not throw")]
        public void RemovingTransaction_WithValidParameters_ShouldNotThrow()
        {
            // ARRANGE
            var categoryId = 8;
            var categoryName = new Name("Educação");
            var descriptionCategory = "Valores destinados a cursos e meetups";
            var category = new Category(categoryId, categoryName, descriptionCategory);

            var idUser = 12;
            var userName = new Name("Paula Andrade");
            var email = new Email("pandrade@gmail.com");
            var passwordHash = "sTTrINg22PHshC";
            var user = new User(idUser, categoryName, email, passwordHash);

            var idCashflow = 1;
            var cashflow = new Cashflow(idCashflow, user);

            var idTransaction = 3;
            var amount = new Cash((decimal)1000.00);
            var date = DateTime.Now;
            var descriptionTransaction = "Viagem de férias";
            var type = TransactionType.Expense;
            var transaction = new Transaction(idTransaction, amount, date, descriptionTransaction, type, category, cashflow);
            cashflow.AddTransaction(transaction);


            // ACT
            Action action = () => cashflow.RemoveTransaction(transaction);

            // ASSERT
            action.ShouldNotThrow();
            cashflow.Transactions.Count().ShouldBeEquivalentTo(0);

        }

        [Fact(DisplayName = "Removing transaction with valid parameters CurrentBalance Should be 0")]
        public void RemovingTransaction_WithValidParameters_CurrentBalanceShouldBeZero()
        {
            // ARRANGE
            var categoryId = 8;
            var categoryName = new Name("Educação");
            var descriptionCategory = "Valores destinados a cursos e meetups";
            var category = new Category(categoryId, categoryName, descriptionCategory);

            var idUser = 12;
            var userName = new Name("Paula Andrade");
            var email = new Email("pandrade@gmail.com");
            var passwordHash = "sTTrINg22PHshC";
            var user = new User(idUser, categoryName, email, passwordHash);

            var idCashflow = 1;
            var cashflow = new Cashflow(idCashflow, user);

            var idTransaction = 3;
            var amount = new Cash((decimal)1000.00);
            var date = DateTime.Now;
            var descriptionTransaction = "Viagem de férias";
            var type = TransactionType.Expense;
            var transaction = new Transaction(idTransaction, amount, date, descriptionTransaction, type, category, cashflow);
            cashflow.AddTransaction(transaction);

            // ACT
            cashflow.RemoveTransaction(transaction);

            // ASSERT
            cashflow.CurrentBalance.ShouldBe(0);
            cashflow.Transactions.Count().ShouldBeEquivalentTo(0);

        }

        [Fact(DisplayName = "Add null transaction should throw argument null exception")]
        public void AddNullTransaction_ArgumentNullException()
        {
            // ARRANGE
            var categoryId = 8;
            var categoryName = new Name("Educação");
            var descriptionCategory = "Valores destinados a cursos e meetups";
            var category = new Category(categoryId, categoryName, descriptionCategory);

            var idUser = 12;
            var userName = new Name("Paula Andrade");
            var email = new Email("pandrade@gmail.com");
            var passwordHash = "sTTrINg22PHshC";
            var user = new User(idUser, categoryName, email, passwordHash);

            var idCashflow = 1;
            var cashflow = new Cashflow(idCashflow, user);

            Transaction transactionB = null;

            // ACT
            Action action = () => cashflow.AddTransaction(transactionB);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();

        }

    }
}
