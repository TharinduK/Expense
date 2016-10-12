using System;
using Expense.Core;
using Expense.Core.Exceptions;
using System.Collections.Generic;

namespace Expense.CoreTests.Unit
{
    internal class FakeExpenseRepository : IExpenseRepository
    {
        public List<ExpenseJournal> Expenses { get { return _expenses; } internal set { _expenses = value; } }
        public int lastExpJournalID = 0;
        private List<ExpenseJournal> _expenses = new List<ExpenseJournal>();
        private List<string> _category = new List<string>();
        private Dictionary<string, Merchant> _mercahnt = new Dictionary<string, Merchant>();
        public List<string> Categories
        {
            get { return _category; }
            set { _category = value; }
        }

        public Dictionary<string, Merchant> Merchants
        {
            get { return _mercahnt; }
            set { _mercahnt = value; }
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