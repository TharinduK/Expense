using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Expense.Core;
using Expense.DALInMemory;
using Expense.Web.MVC4.ViewModel;

namespace Expense.Web.MVC4.Controllers
{
    public partial class HomeController
    {
        public class ExpenseController:Controller
        {
            private readonly IExpenseRepository _repository;
            public ExpenseController():this(null)
            {

            }
            public ExpenseController(IExpenseRepository repo = null)
            {
                _repository = repo ?? new ExpenseRepository();
            }

            public ActionResult Expenses()
            {
                var expList = _repository.GetAllExpences();
                List<ExpenseJournalViewModel> results = new List<ExpenseJournalViewModel>();

                foreach (var e in expList) results.Add(ExpenseJournalMapper.Map(e));
                return View(results);
            }

            public ActionResult AddExpense()
            {
                return View();
            }

            [HttpPost]
            public ActionResult AddExpense(ExpenseJournalViewModel ex)
            {
                if (ModelState.IsValid && AllRequiredInformationCollected(ex))
                {
                    var amount = decimal.Parse(ex.Amount);
                    var date = DateTime.Parse(ex.ExpneseDate);
                    var tran = new AddExpenseTransaction(amount, date, ex.Merchant, ex.Category, _repository);

                    if (tran.Execute()) ModelState.Clear();  //clear to add new expense 
                    else ModelState.AddModelError("", "Error adding expense ");
                }
                return View();
            }

            public bool AllRequiredInformationCollected(ExpenseJournalViewModel model)
            {
                if (string.IsNullOrWhiteSpace(model.Amount)) return false;
                if (string.IsNullOrWhiteSpace(model.Category)) return false;
                if (string.IsNullOrWhiteSpace(model.ExpneseDate)) return false;
                if (string.IsNullOrWhiteSpace(model.Merchant)) return false;
                return true;
            }
        }
    }
}