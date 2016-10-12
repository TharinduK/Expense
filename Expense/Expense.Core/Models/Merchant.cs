using System;
using System.Diagnostics.Contracts;

namespace Expense.Core
{
    public class Merchant
    {
        public bool IsActive { get; set; }
        public string MerchantAlias { get; set; }
        public string MerchantName { get; set; }
        public string Notes { get; set; }

        public Merchant(string merchantName, string merchantAlias, string notes = "", bool isActive = false)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(merchantName));
            Contract.Requires(!string.IsNullOrWhiteSpace(merchantAlias));

            if (string.IsNullOrWhiteSpace(merchantName)) throw new ArgumentNullException("Merchant name can not be empty");
            if (string.IsNullOrWhiteSpace(merchantAlias)) throw new ArgumentNullException("Merchant alias can not be empty");

            MerchantName = merchantName;
            MerchantAlias = merchantAlias.ToUpper();
            Notes = notes;
            IsActive = isActive;
        }

        public override string ToString()
        {
            return $"Name:{MerchantName}, Alias:{MerchantAlias},Notes:{Notes},isActive:{IsActive}";
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            var objectToCompare = obj as Merchant;

            if (objectToCompare.MerchantAlias != MerchantAlias) return false;
            if (objectToCompare.MerchantName != MerchantName) return false;
            if (objectToCompare.Notes != Notes) return false;
            if (objectToCompare.IsActive != IsActive) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}