using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SparkyXUnitTest
{

    // the problem with this Test is that we are checking both
    // bankAccount and LogBook.
    // Unit Tests are just meant to check the functionality of
    // one. LogBook should be mocked.
    public class BankAccountXUnitTests
    {
        private BankAccount bankAccount;

        public BankAccountXUnitTests()
        {
            // dependency injection
            // also, we won't pass in an instance of the real LogBook
            // because we don't want to test for it too.
            // On this class we are just testing for BankAccount
            // bankAccount = new(new LogBook());
            bankAccount = new(new FakeLogBook());
        }

        [Fact]
        public void DepositSuccessful()
        {
            var result = bankAccount.Deposit(100);

            Assert.True(result);
            Assert.Equal(100, bankAccount.GetBalance());
        }
    }
}
