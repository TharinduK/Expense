using Expense.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Expense.Web.MVC4.ViewModel    
{
    public static class MerchantViewModelConverter
    {
        public static MerchantViewModel ToMerchantViewModel(Merchant merchant)
        {
            return new MerchantViewModel
            {
                Alias = merchant.MerchantAlias,
                Name = merchant.MerchantName,
                Notes = merchant.Notes,
                Status = merchant.IsActive ? "Active" : "Inactive"
            };
        }

        public static Merchant ToMerchant(MerchantViewModel merchant)
        {
            return new Merchant(merchant.Name, 
                merchant.Alias, 
                merchant.Notes, 
                merchant.Status.Equals("Active", StringComparison.CurrentCultureIgnoreCase) ? true : false);

        }

        public static IEnumerable<MerchantViewModel> ToMerchantViewModelCollection(IEnumerable<Merchant> results)
        {
            foreach (var m in results)
                yield return ToMerchantViewModel(m);
        }
    }
}