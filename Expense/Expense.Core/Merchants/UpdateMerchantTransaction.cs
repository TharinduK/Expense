using System;
using Expense.Core;

namespace Expense.Core
{
    public class UpdateMerchantTransaction : Transaction
    {
        Merchant _updatedMerchant;
        private string merchAlias => _updatedMerchant.MerchantAlias;
        private bool merchIsActive => _updatedMerchant.IsActive;
        private string merchName => _updatedMerchant.MerchantName;
        private string merchNotes => _updatedMerchant.Notes;

        public UpdateMerchantTransaction(IExpenseRepository repo, IApplicationLogger log, Merchant updatedMerchant)
            : base(repo, log)
        {
            _updatedMerchant = updatedMerchant;
        }

        public override void Execute()
        {
            try
            {
                _repository.UpdateMerchant(_updatedMerchant);
                WasExecutionSucessfull = true;
            }
            catch (Exception ex)
            {
                WasExecutionSucessfull = false;
                _applicationLogger.LogError(ex.Message, ex);
            }
        }
    }
}