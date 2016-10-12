using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Expense.Core
{
    public class GetAllExpences : Transaction
    {
        public IEnumerable<ExpenseJournal> Results = Enumerable.Empty<ExpenseJournal>();
        public GetAllExpences(IExpenseRepository repo, IApplicationLogger log)
            : base(repo, log)
        {
        }

        public override void Execute()
        {
            try
            {
                Results = _repository.GetAllExpences();
                WasExecutionSucessfull = true;
            }
            catch (Exception ex)
            {
                _applicationLogger.LogError(ex.Message, ex);
                WasExecutionSucessfull = false;
            }
        }
    }
}