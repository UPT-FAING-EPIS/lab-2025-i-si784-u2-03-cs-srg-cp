using Bank.Domain;
using NUnit.Framework;
namespace Bank.Domain.Tests
{
    public class BankAccountTests
    {
        [Test]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            account.Debit(debitAmount);
            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
            // NUnit.Framework.Assert.That(actual, Is.EqualTo(expected).Within(0.001), "Account not debited correctly");
        }

        [Test]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act and assert
            Assert.Throws<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

        [Test]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            var account = new BankAccount("Mr. Bryan Walton", 11.99);
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(20.0));
            StringAssert.Contains(BankAccount.DebitAmountExceedsBalanceMessage, ex.Message);
        }


        // casos de prueba 
        [Test]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double creditAmount = 5.01;
            double expected = 17.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Credit(creditAmount);

            // Assert
            double actual = account.Balance;
            NUnit.Framework.Assert.That(actual, Is.EqualTo(expected).Within(0.001), "Account not debited correctly");
        }

        [Test]
        public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            var account = new BankAccount("Mr. Bryan Walton", 100);
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => account.Credit(-50));
            Assert.That(ex.ParamName, Is.EqualTo("amount")); 
        }

        // getters
        [Test]
        public void CustomerName_ShouldReturnCorrectName()
        {
            var account = new BankAccount("Mr. Bryan Walton", 100);
            Assert.That(account.CustomerName, Is.EqualTo("Mr. Bryan Walton"), "Customer name is not correct");
        }

        [Test]
        public void Balance_ShouldReturnCorrectInitialBalance()
        {
            var account = new BankAccount("Mr. Bryan Walton", 100);
            Assert.AreEqual(100, account.Balance);
        }

        [Test]
        public void Debit_WithValidAmount_ShouldDecreaseBalance()
        {
            var account = new BankAccount("Mr. Bryan Walton", 100);
            account.Debit(40);
            Assert.AreEqual(60, account.Balance);
        }

    }
}