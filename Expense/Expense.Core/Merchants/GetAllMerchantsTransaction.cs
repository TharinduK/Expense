using System;
using Expense.Core;
using System.Collections.Generic;

namespace Expense.Core
{
    public class GetAllMerchantsTransaction: Transaction
    {
        public IEnumerable<Merchant> Results { get; private set; }

        public GetAllMerchantsTransaction(IExpenseRepository repo, IApplicationLogger log)
            :base(repo, log)
        {
        }
        

        public override void Execute()
        {
            try
            {
                Results = _repository.GetAllMerchants();
                WasExecutionSucessfull = true;
            }
            catch (Exception ex)
            {
                WasExecutionSucessfull = false;
                _applicationLogger.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}