using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public interface ILogBook
    {
        public int LogSeverity { get; set; }
        public string LogType { get; set; }
        void Message(string message);

        bool LogToDb(string message);

        bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal);

        string MessageThatReturnsString(string message);

        bool LogMessageWithOutputResult(string str, out string outputStr);

        bool LogMessageWithRefObject(ref Customer customer);
    }
    public class LogBook : ILogBook
    {
        public int LogSeverity { get; set; }
        public string LogType { get; set; }

        public bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal)
        {
            if (balanceAfterWithdrawal >= 0)
            {
                Console.WriteLine("Success");
                return true;
            }
            Console.WriteLine("Failure");
            return false;
        }

        public bool LogMessageWithOutputResult(string str, out string outputStr)
        {
            outputStr = "Hello " + str;
            return true;
        }

        public bool LogMessageWithRefObject(ref Customer customer)
        {
            return true;
        }

        public bool LogToDb(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public string MessageThatReturnsString(string message)
        {
            Console.WriteLine(message);
            return message.ToLower();
        }
    }

    public class FakeLogBook : ILogBook
    {
        public int LogSeverity { get; set; }
        public string LogType { get; set; }

        public bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal)
        {
            throw new NotImplementedException();
        }

        public bool LogMessageWithOutputResult(string str, out string outputStr)
        {
            throw new NotImplementedException();
        }

        public bool LogMessageWithRefObject(ref Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool LogToDb(string message)
        {
            throw new NotImplementedException();
        }

        public void Message(string message)
        {
            // no logic here
        }

        public string MessageThatReturnsString(string message)
        {
            throw new NotImplementedException();
        }
    }
}
