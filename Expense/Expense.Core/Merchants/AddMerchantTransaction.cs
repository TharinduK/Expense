using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense.Core
{
    public class AddMerchantTransaction : Transaction
    {
        private string merchantAlias;
        private string merchantName;
        private string merchantNotes;
        private bool merchantStatus;
        
        public AddMerchantTransaction(IExpenseRepository repo, IApplicationLogger log, string merchantName, string merchantAlias, string merchantNotes, bool merchantStatus)
            : base(repo, log)
        {
            this.merchantName = merchantName;
            this.merchantAlias = merchantAlias;
            this.merchantNotes = merchantNotes;
            this.merchantStatus = merchantStatus;
        }

        public override void Execute()
        {
            try
            {
                var merchantToAdd = new Merchant(merchantName, merchantAlias, merchantNotes, merchantStatus);
               _repository.AddNewMerchant(merchantToAdd);
                WasExecutionSucessfull = true;
            }
            catch (Exception ex)
            {
                _applicationLogger.LogError(Message: ex.Message, Exception: ex);
                WasExecutionSucessfull = false;
            }
            
        }
    }
}
