namespace BankAccount.Tests
{
    using System;
    using NUnit.Framework;

    public class Tests
    {
        [TestCase("Andrew", 10.5)]
        public void Constructor_ShouldSetValidValuesCorrectly(string name, decimal balance)
        {
            var bankAccount = new BankAccount(name, balance);

            var expectedName = name;
            var actualName = bankAccount.Name;

            var expectedBalance = balance;
            var actualBalance = bankAccount.Balance;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedBalance, actualBalance);
        }

        [TestCase("An", 10.5)]
        [TestCase("Anasfhnaskfhafbacasdfasfasjlascn", 10.5)]
        public void Constructor_ShouldThrowArgumentExceptionForInvalidName(string name,
            decimal balance)
        {
            Assert.Throws<ArgumentException>(() => new BankAccount(name, balance));
        }

        [TestCase("Andrew", -15)]
        public void Constructor_ShouldThrowArgumentExceptionForInvalidBalance(string name,
            decimal balance)
        {
            Assert.Throws<ArgumentException>(() => new BankAccount(name, balance));
        }

        [TestCase("Andrew", 10, 5.50)]
        public void Deposit_ValidAmount_ShouldIncreaseBalance(string name, decimal balance, 
            decimal amount)
        {
            var bankAccount = new BankAccount(name, balance);
            bankAccount.Deposit(amount);

            var expected = 15.50m;
            var actual = bankAccount.Balance;

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Andrew", 10, 0)]
        [TestCase("Andrew", 10, -3.5)]
        public void Deposit_InvalidAmount_ShouldThrowInvalidOperationException(string name, decimal balance,
            decimal amount)
        {
            var bankAccount = new BankAccount(name, balance);

            Assert.Throws<InvalidOperationException>(() => bankAccount.Deposit(amount));
        }

        [TestCase("Andrew", 10, 5.50)]
        public void Withdraw_ValidAmount_ShouldDecreaseBalance(string name, decimal balance,
            decimal amount)
        {
            var bankAccount = new BankAccount(name, balance);
            bankAccount.Withdraw(amount);

            var expected = 4.50m;
            var actual = bankAccount.Balance;

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Andrew", 10, 10)]
        [TestCase("Andrew", 10, 11.5)]
        [TestCase("Andrew", 10, -1.5)]
        public void Withdraw_InvalidAmount_ShouldThrowInvalidOperationException(string name, decimal balance,
            decimal amount)
        {
            var bankAccount = new BankAccount(name, balance);

            Assert.Throws<InvalidOperationException>(() => bankAccount.Withdraw(amount));
        }
    }
}