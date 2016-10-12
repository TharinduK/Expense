using System;
using System.Diagnostics.Contracts;

namespace Expense.Core
{
    public class AddExpenseTransaction : AddExpenceJournalTransaction
    {
        public AddExpenseTransaction(decimal amount, DateTime expneseDate, string merchantAlias, string categoryAlias, IExpenseRepository rep)
            : base(amount, expneseDate, merchantAlias, categoryAlias, rep)
        {
            Contract.Requires(amount > 0);
            Contract.Requires(!string.IsNullOrWhiteSpace(merchantAlias));
            Contract.Requires(!string.IsNullOrWhiteSpace(categoryAlias));
        }
    }
}