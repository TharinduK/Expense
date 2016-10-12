using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense.Core
{
    public class AddRefundTransaction : AddExpenceJournalTransaction
    {
        public AddRefundTransaction(decimal refundAmount, DateTime expneseDate, string merchantAlias, string categoryAlias, IExpenseRepository rep)
            : base(-refundAmount, expneseDate, merchantAlias, categoryAlias, rep)
        {
            Contract.Requires(refundAmount > 0);
            Contract.Requires(!string.IsNullOrWhiteSpace(merchantAlias));
            Contract.Requires(!string.IsNullOrWhiteSpace(categoryAlias));
        }
    }
}
