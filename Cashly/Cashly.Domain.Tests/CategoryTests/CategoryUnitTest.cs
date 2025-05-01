using Cashly.Domain.ValueObjects;
using Cashly.Domain.Entities;
using Shouldly;
using Cashly.Domain.Exceptions;
using Cashly.Domain.Enums;

namespace Cashly.Domain.Tests.CategoryTests
{
    public class CategoryUnitTest
    {
        [Fact(DisplayName = "Create category with valid state")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            // ARRANGE
            var id = 8;
            var name = new Name("Educação");
            var description = "Valores destinados a cursos e meetups";

            // ACT
            Action action = () => new Category(id, name, description);
           
            // ASSERT
            action.ShouldNotThrow();
        }

        [Fact(DisplayName = "Create a category without a description")]
        public void CreateCategory_WithoutDescription_ResultObjectValidState()
        {            
            // ARRANGE
            var id = 8;
            var name = new Name("Educação");
            
            // ACT
            Action action = () => new Category(id, name, null);
            
            //ASSERT
            action.ShouldNotThrow();
        }

        [Fact(DisplayName = "Create a category with negative value")]
        public void CreateCategory_WithNegativeId_DomainExceptionValidation()
        {
            // ARRANGE
            var id = -8;
            var name = new Name("Educação");
            var description = "Valores destinados a cursos e meetups";

            // ACT
            Action action = () => new Category(id, name, description);

            //ASSERT
            action.ShouldThrow<DomainExceptionValidation>().Message.ShouldBe("Invalid Id value");
        }

        [Fact(DisplayName = "Create a category with Empty Name")]
        public void CreateCategory_WithEmptyName_DomainExceptionValidation()
        {
            // ARRANGE
            var id = 8;
            var description = "Valores destinados a cursos e meetups";

            // ACT
            Action action = () => new Category(id, new Name(""), description);

            // ASSERT
            var ex = action.ShouldThrow<DomainExceptionValidation>();
            ex.Message.ShouldBe("Name cannot be null or empty");
        }

        [Fact(DisplayName = "Create a category with less than 4 characters")]
        public void CreateCategory_WithNotEnoughCharacters_DomainExceptionValidation()
        {            
            // ARRANGE
            var id = 8;
            var description = "Valores destinados a viagens";

            // ACT
            Action action = () => new Category(id, new Name("Voo"), description);

            // ASSERT
            var ex = action.ShouldThrow<DomainExceptionValidation>();
            ex.Message.ShouldBe("Name must be longer than 3 characters");
        }

        [Fact(DisplayName = "Create a category with White Space Name")]
        public void CreateCategory_WithWhiteSpaceName_DomainExceptionValidation()
        {
            // ARRANGE
            var id = 8;
            var description = "Valores destinados a educação";


            // ACT
            Action action = () => new Category(id, new Name(" "), description);

            // ASSERT
            action.ShouldThrow<DomainExceptionValidation>().Message.ShouldBe("Name cannot be null or empty");
        }
        [Fact(DisplayName = "Create category and add valid transaction")]
        public void CreateCategory_AddTransactionWithValidValues_ResultValidObjectState()
        {
            // ARRANGE
            var categoryId = 5;
            var categoryName = new Name("Academia");
            var categoryDescription = "Valores destinados a academia e suplementos";
            var category = new Category(categoryId, categoryName, categoryDescription);

            var userId = 2;
            var userName = new Name("Josué");
            var userEmail = new Email("jjosuejenivaldo@gmail.com");
            var userPasswordHash = "ALgUmhASH126HomOGenEo8906";
            var user = new User(userId, userName, userEmail, userPasswordHash);

            var cashflowId = 6;
            var cashflow = new Cashflow(cashflowId, user);

            var transactionId = 7;
            var amount = new Cash(100);
            var date = DateTime.UtcNow;
            var description = "Mensalidade de academia";
            var type = TransactionType.Expense;
            var categoryTransaction = category;
            var cashflowTransaction = cashflow;
            var transaction = new Transaction(transactionId, amount, date, description, type, categoryTransaction, cashflowTransaction);

            // ACT
            Action action = () => category.AddTransaction(transaction);

            // ASSERT
            action.ShouldNotThrow();
        }
        [Fact(DisplayName = "Create a category and add null transaction")]
        public void CreateCategory_AddNullTransaction_DomainExceptionValidation()
        {
            // ARRANGE
            var categoryId = 5;
            var categoryName = new Name("Academia");
            var categoryDescription = "Valores destinados a academia e suplementos";
            var category = new Category(categoryId, categoryName, categoryDescription);

            var userId = 2;
            var userName = new Name("Josué");
            var userEmail = new Email("jjosuejenivaldo@gmail.com");
            var userPasswordHash = "ALgUmhASH126HomOGenEo8906";
            var user = new User(userId, userName, userEmail, userPasswordHash);

            var cashflowId = 6;
            var cashflow = new Cashflow(cashflowId, user);

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
            var categoryId = 5;
            var categoryName = new Name("Academia");
            var categoryDescription = "Valores destinados a academia e suplementos";
            var category = new Category(categoryId, categoryName, categoryDescription);

            var categoryIdB = 6;
            var categoryNameB = new Name("Computador");
            var categoryDescriptionB = "Valores destinados a compra de equipamentos";
            var categoryB = new Category(categoryIdB, categoryNameB, categoryDescriptionB);

            var userId = 2;
            var userName = new Name("Josué");
            var userEmail = new Email("jjosuejenivaldo@gmail.com");
            var userPasswordHash = "ALgUmhASH126HomOGenEo8906";
            var user = new User(userId, userName, userEmail, userPasswordHash);

            var cashflowId = 6;
            var cashflow = new Cashflow(cashflowId, user);

            var transactionId = 7;
            var amount = new Cash(100);
            var date = DateTime.UtcNow;
            var description = "Computador novo para trabalho";
            var type = TransactionType.Expense;
            var categoryTransaction = categoryB;
            var cashflowTransaction = cashflow;
            var transaction = new Transaction(transactionId, amount, date, description, type, categoryTransaction, cashflowTransaction);

            // ACT
            Action action = () => category.AddTransaction(transaction);

            // ASSERT
            action.ShouldThrow<DomainExceptionValidation>().Message.ShouldBe("The transaction does not belong to this category");
        }
    }
}
