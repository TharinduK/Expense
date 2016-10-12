using System;
using Expense.Core;
using System.Collections.Generic;

namespace Expense.CoreTests.Unit
{
    public class FakeApplicationLogger : IApplicationLogger
    {
        public List<Exception> ExceptionList { get; private set; } = new List<Exception>();
        public List<string> MessageList { get; private set; } = new List<string>();


        public void LogError(string Message, Exception Exception)
        {
            MessageList.Add(Message);
            ExceptionList.Add(Exception);
        }
    }
}