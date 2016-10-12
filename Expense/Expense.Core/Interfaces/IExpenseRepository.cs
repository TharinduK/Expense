using System;
using System.Collections.Generic;

namespace Expense.Core
{
    public interface IExpenseRepository
    {
        //IncomeAccount GetIncomeAccoutByAlias(string alias);
        //ExpenseAccount GetExpenseAccoutByAlias(string alias);
        //IMerchant GetMerchantByAlias(string alias);
        //void SaveAccount(IMerchant m);
        //void SaveNewAccount(IMerchant m);
        //void SaveNewAccount(IAccount a);
        //void SaveAccount(IAccount acc);
        ////IEnumerator<Account> GetActiveIncomeAccounts();
        //List<IncomeAccount> GetActiveIncomeAccounts();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="expenseDate"></param>
        /// <param name="merchant"></param>
        /// <param name="category"></param>
        /// <returns>Expense Journal ID for new record (0 if not added)</returns>
        int AddExpenseJournal(decimal amount, DateTime expenseDate, string merchant, string category);
        void UpdateMerchant(Merchant _updatedMerchant);
        IEnumerable<ExpenseJournal> GetAllExpences();
        void AddNewMerchant(Merchant merchantToAdd);
        bool IsExistingMerchant(string merchantAlias);
        bool IsExistingCategory(string category);
        Merchant GetMerchant(string _merchantAlias);
        IEnumerable<Merchant> GetAllMerchants();
    }
}