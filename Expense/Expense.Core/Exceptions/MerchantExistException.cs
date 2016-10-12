using System;

namespace Expense.Core.Exceptions
{
    public class MerchantDoNotExistException : Exception
    {
        public MerchantDoNotExistException()
        {
        }

        public MerchantDoNotExistException(string message) : base(message)
        {
        }

        public MerchantDoNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}