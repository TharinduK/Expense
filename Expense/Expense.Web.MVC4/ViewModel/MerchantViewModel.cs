using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Expense.Web.MVC4.ViewModel
{
    public class MerchantViewModel
    {
        public string Alias { get; set; }
        public string Name { get; set; }
        public string Notes { get; internal set; }
        public string Status { get; internal set; }
    }
}