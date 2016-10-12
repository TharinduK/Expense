using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Expense.Web.MVC4.ViewModel
{
    public static class ExpenseJournalMapper
    {
        public static ExpenseJournalViewModel Map(Expense.Core.ExpenseJournal ej)
        {
            return new ExpenseJournalViewModel
            {
                Amount = ej.Amount.ToString("C"),
                Category = ej.Category,
                ExpneseDate = ej.ExpneseDate.ToShortDateString(),
                Merchant = ej.Merchant
            };
        }

        public static Expense.Core.ExpenseJournal Map(ExpenseJournalViewModel ej)
        {
            throw new NotImplementedException();
            DateTime date;
            if (!DateTime.TryParse(ej.ExpneseDate, out date)) return null;
            decimal amnt;
            if (!decimal.TryParse(ej.Amount, out amnt)) return null;

            return new Expense.Core.ExpenseJournal(amnt, date, ej.Merchant, ej.Category);
        }
    }
}