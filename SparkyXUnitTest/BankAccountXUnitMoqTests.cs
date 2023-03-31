using Moq;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SparkyXUnitTest
{
    public class BankAccountXUnitMoqTests
    {
        private BankAccount account;
        public void Setup()
        {

        }

        [Fact]
        public void DepositSuccessful()
        {
            var LogBookMock = new Mock<ILogBook>(); 
            BankAccount bankAccount = new(LogBookMock.Object);
            
            var result = bankAccount.Deposit(100);

            Assert.True(result);
            Assert.Equal(100, bankAccount.GetBalance());
        }

        [Fact]
        public void WithdrawalSuccesful()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.IsAny<int>())).Returns(true);
            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(200);
            
            var result = bankAccount.Withdraw(100);
            
            Assert.True(result);

        }

        [Theory]
        [InlineData(200,100)]
        [InlineData(200,150)]
        public void WithdrawalSuccesfulWithTestCase(int balance, int withdrawal)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x>=0))).Returns(true);
            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(balance);

            var result = bankAccount.Withdraw(withdrawal);

            Assert.True(result);

        }

        [Theory]
        [InlineData(100, 200)]
        [InlineData(100, 150)]
        public void WithdrawalUnsuccesful(int balance, int withdrawal)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x < 0))).Returns(false);
            // or alternatively we could write
            // logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x >= 0))).Returns(true);
            // since the argument of LogBalanceAfterWithdrawal is less than 0, it will return false.
            // because the default return is false
            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(balance);

            var result = bankAccount.Withdraw(withdrawal);

            Assert.False(result);

        }

        [Theory]
        [InlineData(100, 200)]
        [InlineData(100, 150)]
        public void WithdrawalUnsuccesfulWithItIsInRange(int balance, int withdrawal)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x >= 0))).Returns(true);
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue,-1,Moq.Range.Inclusive))).Returns(false);
            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(balance);

            var result = bankAccount.Withdraw(withdrawal);

            Assert.False(result);

        }

        // this unit test is not a proper unit test in that it tests a mock
        // still the example is useful for scenarios previous to test completion
        // where we want to test that we setup a mock correctly.
        [Fact]
        public void ReturnsaStringMessage()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "hello";

            // logMock.Setup(u => u.MessageThatReturnsString(It.IsAny<string>())).Returns((string str) => str);
            // Returns((string str => str) means it receives a string and it outputs a string.
            // you could do instead
            logMock.Setup(u => u.MessageThatReturnsString(It.IsAny<string>())).Returns((string str) => str.ToLower());
            // to say that it receives a string and it returns a string in lowercase.

            Assert.Equal(desiredOutput, logMock.Object.MessageThatReturnsString("HELLo"));
        }

        // Again this is not a sample unit test
        // here we are just testing that the setup returns what we expect it to
        [Fact]
        public void ReturnsaOutputVariableofTypeString()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "Hello";
            // here we are setting up that the method returns true
            // but also that the out variable should contain Hello
            logMock.Setup(u => u.LogMessageWithOutputResult(It.IsAny<string>(), out desiredOutput)).Returns(true);
            string desiredOutput2 = "";
            
            // here we are just testing that LogMessageWithOutputResult returns true
            Assert.True(logMock.Object.LogMessageWithOutputResult("Ben", out desiredOutput2));
            // after this assert executes the desiredOutput2 is set to Hello
            // here we are testing that the empty string result is equal to the desired output
            Assert.Equal(desiredOutput, desiredOutput2);
            
        }

        [Fact]
        public void WorkingWithRefObject()
        {
            var logMock = new Mock<ILogBook>();
            Customer customer = new();
            Customer customerNotUsed = new();

            // here we are saying that when we call method
            // LogMessageWithRefObject and we pass exactly the object customer (of type customer)
            // we expect a return value of true
            logMock.Setup(u => u.LogMessageWithRefObject(ref customer)).Returns(true);

            // this will work
            Assert.True(logMock.Object.LogMessageWithRefObject(ref customer));
            // this next Assert won't work even though we are passing an object of type Customer
            // because by reference we know it is not the same object.
            // Assert.IsTrue(logMock.Object.LogMessageWithRefObject(ref customerNotUsed));
        }

        // NUnit Commented Code
        //[Test]
        //public void ReturnsaStringMessage2()
        //{
        //    var logMock = new Mock<ILogBook>();
        //    string desiredOutput = "hello";

        //    // here we are setting up the method to receive a Hi as parameter
        //    logMock.Setup(u => u.MessageThatReturnsString("Hi")).Returns((string str) => str.ToLower());

        //    // since we are asserting that the method receives a HELLo instead, the previous
        //    // setup won't work and NUnit won't know what to do. So it will return a null object.
        //    // remember that false and Null are the default return values for methods that are incorrectly set up
        //    Assert.That(logMock.Object.MessageThatReturnsString("HELLo"), Is.EqualTo(desiredOutput));
        //}

        [Fact]
        public void SetandGetLogSeverityandLogType()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(u => u.LogSeverity).Returns(10);
            logMock.Setup(u => u.LogType).Returns("warning");
            // you can't set them up like this:
            // logMock.Object.LogSeverity = 10;
            // but if you want to set them up like that you previously have to call
            // logMock.SetupAllProperties();
            // then you can lockMock.Object.LogSeverity = 10; but since you are setting up ALL properties
            // you must also do lockMock.Object.LogType = "warning";
           
            Assert.Equal(10, logMock.Object.LogSeverity);
            Assert.Equal("warning", logMock.Object.LogType);
            
        }

        [Fact]
        public void Callbacks()
        {
            var logMock = new Mock<ILogBook>();
            string logTemp = "Hello, ";
            logMock.Setup(u => u.LogToDb(It.IsAny<string>())).
                Returns(true).Callback((string str) => logTemp += str);
            // the call back will capture the string parameter which is any string
            // and append it to "Hello ".
            // such that
            logMock.Object.LogToDb("Ben");
            // will result in "Hello, Ben" passed as parameter);
            Assert.Equal("Hello, Ben", logTemp);


            int counter = 5;
            logMock.Setup(u => u.LogToDb(It.IsAny<string>())).
                Returns(true).Callback(() => counter++);

            logMock.Object.LogToDb("Ben");
            logMock.Object.LogToDb("Ben");
            // will result in "Hello, Ben" passed as parameter);
            Assert.Equal(7, counter);

            // callbacks can be also called before returning a value
            // logMock.Setup(u => u.LogToDb(It.IsAny<string>())).
            // Callback(() => counter++).Returns(true);
        }

        // how to test if a method was called or a property was accessed
        [Fact]
        public void VerifyMethodCalledandPropertyAccessed()
        {
            var logMock = new Mock<ILogBook>();
            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(100);
            Assert.Equal(100, bankAccount.GetBalance());

            logMock.Verify(u => u.Message(It.IsAny<string>()), Times.Exactly(2));
            logMock.Verify(u => u.Message("Test"), Times.AtLeastOnce);
            logMock.VerifySet(u => u.LogSeverity = 101, Times.Once);
            logMock.VerifyGet(u => u.LogSeverity, Times.Once);
        }
    }
}
