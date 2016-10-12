using System;
using Expense.Core;
using Expense.Core.Exceptions;
using System.Collections.Generic;

namespace Expense.DALInMemory
{
    public class ExpenseRepository : IExpenseRepository
    {
        public List<ExpenseJournal> Expenses { get; internal set; } = new List<ExpenseJournal>();
        public int lastExpJournalID = 0;
        public List<string> Categories { get; set; } = new List<string>();
        public Dictionary<string, Merchant> Merchants { get; set; } = new Dictionary<string, Merchant>();
        public ExpenseRepository()
        {
            Expenses.Add(new ExpenseJournal(100.5M, new DateTime(2016, 08, 20), "PNS", "grossary"));
            Expenses.Add(new ExpenseJournal(10.5M, new DateTime(2015, 08, 20), "WG", "grossary"));
            Expenses.Add(new ExpenseJournal(10.5M, new DateTime(2016, 08, 11), "WalMart", "entertainment"));
            Expenses.Add(new ExpenseJournal(20.75M, new DateTime(2016, 08, 23), "AMC", "entertainment"));
            Expenses.Add(new ExpenseJournal(100.5M, new DateTime(2017, 08, 20), "Copps", "grossary"));
            Expenses.Add(new ExpenseJournal(100.5M, new DateTime(2016, 08, 20), "PNS", "grossary"));

            Merchants.Add("PNS", new Merchant("PNS", "PNS"));
            Merchants.Add("WF", new Merchant("WF", "Wholefood"));
            Merchants.Add("WalMart", new Merchant("WalMart", "WalMart"));
            Merchants.Add("AMC", new Merchant("AMC", "AMC"));
            Merchants.Add("Copps", new Merchant("Copps", "Copps"));

            Categories.Add("grossary");
            Categories.Add("entertainment");
        }

        public int AddExpenseJournal(decimal amount, DateTime expenseDate, string merchant, string category)
        {
            var ej = new ExpenseJournal(amount, expenseDate, merchant, category);
            lastExpJournalID++;
            ej.ID = lastExpJournalID;
            Expenses.Add(ej);
            return lastExpJournalID;
        }

        public IEnumerable<ExpenseJournal> GetAllExpences()
        {
            return Expenses;
        }

        public bool IsExistingMerchant(string merchantAias)
        {
            var alias = merchantAias.ToUpper();
            return Merchants.ContainsKey(alias);
        }

        public bool IsExistingCategory(string category)
        {
            var cat = category.ToUpper();
            return Categories.Contains(cat);
        }

        public Merchant GetMerchant(string merchantAlias)
        {
            var alias = merchantAlias.ToUpper();
            if (IsExistingMerchant(alias)) return Merchants[alias];
            else throw new MerchantDoNotExistException();
        }

        void IExpenseRepository.AddNewMerchant(Merchant merchantToAdd)
        {
            if (IsExistingMerchant(merchantToAdd.MerchantAlias)) throw new MerchantDoNotExistException();

            Merchants.Add(merchantToAdd.MerchantAlias, merchantToAdd);
        }

        public IEnumerable<Merchant> GetAllMerchants()
        {
            foreach (var m in Merchants)
                yield return m.Value;
        }

        public void UpdateMerchant(Merchant updatedMerchant)
        {
            var merchantToUpdate = GetMerchant(updatedMerchant.MerchantAlias);
            if (merchantToUpdate != updatedMerchant)
            {
                Merchants[updatedMerchant.MerchantAlias].MerchantName = updatedMerchant.MerchantName;
                Merchants[updatedMerchant.MerchantAlias].Notes = updatedMerchant.Notes;
                Merchants[updatedMerchant.MerchantAlias].IsActive = updatedMerchant.IsActive;
            }
        }
    }
}