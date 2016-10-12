using System;

namespace Expense.Core
{
    public abstract class AddExpenceJournalTransaction
    {
        private readonly IExpenseRepository _repository;

        protected AddExpenceJournalTransaction(decimal amount, DateTime expneseDate, string merchantAlias, string categoryAlias, IExpenseRepository rep)
        {
            Amount = amount;
            ExpenseDate = expneseDate;
            MerchantAlias = merchantAlias;
            CategoryAlias = categoryAlias;
            _repository = rep;
        }

        public DateTime ExpenseDate { get; set; }
        public decimal Amount { get; set; }
        public string CategoryAlias { get; set; }
        public string MerchantAlias { get; set; }
        public int ExpenseJournalId { get; private set; }

        public bool Execute()
        {
            var uppercaseMerchantAlias = MerchantAlias.ToUpper();
            var uppercaseCategoryAlias = CategoryAlias.ToUpper();

            if (!_repository.IsExistingMerchant(uppercaseMerchantAlias)) return false;
            if (!_repository.IsExistingCategory(uppercaseCategoryAlias)) return false;

            var newJournlId = _repository.AddExpenseJournal(Amount, ExpenseDate, uppercaseMerchantAlias, uppercaseCategoryAlias);

            if(newJournlId== 0) return false;

            ExpenseJournalId = newJournlId;
            return true;
        }
    }
}
