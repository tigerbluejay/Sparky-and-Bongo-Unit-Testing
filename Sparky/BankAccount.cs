using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class BankAccount
    {
        public int balance { get; set; }
        // dependency injection:
        private readonly ILogBook _logBook;

        public BankAccount(ILogBook logBook)
        {
            balance = 0;
            _logBook = logBook;
        }

        public bool Deposit(int amount)
        {
            // the four next lines are used to test method and property invokation
            // in the NUnitTest Project
            _logBook.Message("Deposit invoked");
            _logBook.Message("Test");
            _logBook.LogSeverity = 101;
            var temp = _logBook.LogSeverity;
            balance += amount;
            return true;
        }

        public bool Withdraw(int amount)
        {
            if (amount <= balance)
            {
                // this logbook is injected into the constructor
                // it suffices to add a property of the right type
                // write the constructor and we can accesss the LogToDb method.
                _logBook.LogToDb("Withdrawal Amount: " + amount.ToString());
                balance -= amount;
                // will return true if balance after withdrawal is 0 or more
                return _logBook.LogBalanceAfterWithdrawal(balance);
            }
            // will return false if balance after withdrawal is less than 0
            return _logBook.LogBalanceAfterWithdrawal(balance-amount);
        }

        public int GetBalance()
        {
            return balance;
        }
    }
}
