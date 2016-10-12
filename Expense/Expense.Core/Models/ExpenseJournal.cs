using System;
using System.Diagnostics.Contracts;

namespace Expense.Core
{
    public class ExpenseJournal:IEquatable<ExpenseJournal>
    {
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public DateTime ExpneseDate { get; set; }
        public string Merchant { get; set; }
        public int ID { get; set; }

        public ExpenseJournal()
        {
        }

        public ExpenseJournal(decimal Amount, DateTime ExpneseDate, string Merchant, string Category)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(Merchant));
            Contract.Requires(!string.IsNullOrWhiteSpace(Category));
            Contract.Requires(Amount != 0);

            this.Amount = Amount;
            this.ExpneseDate = ExpneseDate;
            this.Merchant = Merchant;
            this.Category = Category;
        }

        public override bool Equals(object obj)
        {
            if (obj is ExpenseJournal) return Equals(obj as ExpenseJournal);
            else return false;
        }
        public bool Equals(ExpenseJournal other)
        {
            return Amount.Equals(other.Amount) && Category.Equals(other.Category)
                && ExpneseDate.Equals(other.ExpneseDate) && Merchant.Equals(other.Merchant);
            //TODO: check if we need an ID - or included time
        }

        public override int GetHashCode()
        {
            return Amount.GetHashCode() + Category.GetHashCode() 
                + ExpneseDate.GetHashCode() + Category.GetHashCode();
        }
    }
}