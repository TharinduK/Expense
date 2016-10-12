using System;

namespace Expense.Core
{
    public interface IApplicationLogger
    {
        void LogError(string Message, Exception Exception);
    }
}