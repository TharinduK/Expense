using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense.Core
{
    public class GetMerchantTransaction : Transaction
    {
        private readonly string _merchantAlias;

        public Merchant Result { get; private set; }

        public GetMerchantTransaction(IExpenseRepository repo, IApplicationLogger log,  string alias) 
            : base(repo, log)
        {
            _merchantAlias = alias;
        }
        
        public override void Execute()
        {
            try
            {
                Result = _repository.GetMerchant(_merchantAlias); //TODO: Check if it is customary to do nullable object for DTO. I assume not becuase DTO dont have methods 
                WasExecutionSucessfull = true;
            }
            catch(Exception ex)
            {
                _applicationLogger.LogError(ex.Message, ex);
                WasExecutionSucessfull = false;
            }
        }
    }
}
