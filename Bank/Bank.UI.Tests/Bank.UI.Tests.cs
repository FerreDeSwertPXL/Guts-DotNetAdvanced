using NUnit.Framework;
using Bank.UI;

namespace Bank.UI.Tests
{
    [TestFixture]
    public class CheckingAccountTests
    {
        [Test]
        public void Constructor_SetsOwnerBalanceAndInterestRate()
        {
            var account = new CheckingAccount("Alice", 1000m, 0.05m);

            Assert.That(account.Owner, Is.EqualTo("Alice"));
            Assert.That(account.Balance, Is.EqualTo(1000m));
            Assert.That(account.InterestRate, Is.EqualTo(0.05m));
        }

        [Test]
        public void Deposit_IncreasesBalance()
        {
            var account = new CheckingAccount("Alice", 100m, 0.05m);

            account.Deposit(50m);

            Assert.That(account.Balance, Is.EqualTo(150m));
        }

        [Test]
        public void Deposit_NegativeAmount_ThrowsException()
        {
            var account = new CheckingAccount("Alice", 100m, 0.05m);

            Assert.Throws<ArgumentException>(() => account.Deposit(-10m));
        }

        [Test]
        public void Withdraw_DecreasesBalance()
        {
            var account = new CheckingAccount("Alice", 100m, 0.05m);

            account.Withdraw(40m);

            Assert.That(account.Balance, Is.EqualTo(60m));
        }

        [Test]
        public void Withdraw_NegativeAmount_ThrowsException()
        {
            var account = new CheckingAccount("Alice", 100m, 0.05m);

            Assert.Throws<ArgumentException>(() => account.Withdraw(-20m));
        }

        [Test]
        public void AddInterest_PositiveBalance_IncreasesBalance()
        {
            var account = new CheckingAccount("Alice", 100m, 0.05m);

            account.AddInterest();

            Assert.That(account.Balance, Is.EqualTo(105m));
        }

        [Test]
        public void AddInterest_NegativeBalance_UsesNegativeInterestRate()
        {
            var account = new CheckingAccount("Alice", -100m, 0.05m);

            account.AddInterest();

            // balance should become MORE negative
            Assert.That(account.Balance, Is.LessThan(-100m));
        }

        [Test]
        public void ToString_ReturnsOwnerAndBalance()
        {
            var account = new CheckingAccount("Alice", 100m, 0.05m);

            var result = account.ToString();

            Assert.That(result, Does.Contain("Alice"));
            Assert.That(result, Does.Contain("100"));
        }
    }
}
