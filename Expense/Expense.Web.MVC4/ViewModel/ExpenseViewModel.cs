using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Expense.Web.MVC4.ViewModel
{
    public class ExpenseJournalViewModel
    {
        [Required]
        [DataType(DataType.Currency)]
        [Range(0.00, 100000, ErrorMessage = "{0} must be between {1} and {2}.")]
        public string Amount { get; set; }

        [Required]
        [MinLength(3, ErrorMessage ="{0} must be more than {1} characters long")]
        public string Category { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string ExpneseDate { get; set; }

        [Required]
        [MinLength(3)]
        public string Merchant { get; set; }
    }
}