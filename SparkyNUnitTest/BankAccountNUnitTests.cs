using NUnit.Framework;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkyNUnitTest
{

    // the problem with this Test is that we are checking both
    // bankAccount and LogBook.
    // Unit Tests are just meant to check the functionality of
    // one. LogBook should be mocked.
    public class BankAccountNUnitTests
    {
        private BankAccount bankAccount;

        [SetUp]
        public void Setup()
        {
            // dependency injection
            // also, we won't pass in an instance of the real LogBook
            // because we don't want to test for it too.
            // On this class we are just testing for BankAccount
            // bankAccount = new(new LogBook());
            bankAccount = new(new FakeLogBook());
        }

        [Test]
        public void DepositSuccessful()
        {
            var result = bankAccount.Deposit(100);

            Assert.IsTrue(result);
            Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));
        }
    }
}
