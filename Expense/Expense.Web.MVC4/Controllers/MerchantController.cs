using Expense.Core;
using Expense.DALInMemory;
using Expense.Web.MVC4.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Expense.Web.MVC4.Controllers
{
    public class MerchantController : Controller
    {
        private readonly IExpenseRepository _repo;
        private IApplicationLogger _log;

        public MerchantController(IExpenseRepository repo, IApplicationLogger log)
        {
            _repo = repo;
            _log = log;
        }
        // GET: Merchant
        public ActionResult Index()
        {
            var tran = new GetAllMerchantsTransaction(_repo, _log);
            tran.Execute();
            var merchants = GetMerchantsViewModel(tran.Results);
            if (tran.WasExecutionSucessfull) return View(merchants);
            else return View(); //TODO: redirect to error page
        }

        private IEnumerable<MerchantViewModel> GetMerchantsViewModel(IEnumerable<Merchant> results)
        {
            foreach (var m in results)
                yield return ConvertMerchant(m);
        }

        // GET: Merchant/Details/5
        public ActionResult Details(string alias)
        {
            MerchantViewModel vmMerchant = GetMerchant(alias);
            return View(vmMerchant);
        }

        private MerchantViewModel GetMerchant(string alias)
        {
            var merchantTransaction = new GetMerchantTransaction(_repo, _log, alias);

            merchantTransaction.Execute();
            var merchant = merchantTransaction.Result;
            var vmMerchant = ConvertMerchant(merchant);
            return vmMerchant;
        }

        private MerchantViewModel ConvertMerchant(Merchant merchant)
        {
            return new MerchantViewModel
            {
                Alias = merchant.MerchantAlias,
                Name = merchant.MerchantName,
                Notes = merchant.Notes,
                Status = merchant.IsActive ? "Active" : "Inactive"
            };
        }

        private Merchant ConvertMerchant(MerchantViewModel merchant)
        {
            return new Merchant(merchant.Name, merchant.Alias, merchant.Notes, merchant.Status == "Active" ? true : false);
            
        }

        // GET: Merchant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Merchant/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Merchant/Edit/5
        public ActionResult Edit(string alias)
        {
            var merch = GetMerchant(alias);

            return View(merch);
        }

        // POST: Merchant/Edit/5
        [HttpPost]
        public ActionResult Edit(MerchantViewModel merchant)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //TODO: figure out how to move instanciation to a different file
                    var tran = new UpdateMerchantTransaction(_repo, _log, ConvertMerchant(merchant));
                    tran.Execute();
                    if (tran.WasExecutionSucessfull) ModelState.Clear();  //clear to add new expense 
                    else ModelState.AddModelError("", "Error adding expense ");
                }
                  return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Merchant/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Merchant/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
