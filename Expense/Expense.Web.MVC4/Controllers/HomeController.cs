using Expense.Core;
using Expense.DALInMemory;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Expense.Web.MVC4.Controllers
{
    public partial class HomeController : Controller
    {
        private readonly IExpenseRepository _repository;
        public HomeController():this(null)
        {

        }
        public HomeController(IExpenseRepository repo = null)
        {
            _repository = repo ?? new ExpenseRepository();
        }
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Index(int id)
        //{
        //    if (id == 5) return HttpNotFound();
        //    else if(id == 6) return View(new ExpenseJournalViewModel { Amount = "50", ExpneseDate = new DateTime(2016,01,01).ToString("MM/dd/yyyy") });
        //    else return View();
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ContactMe()
        {
            return Redirect("http://yahoo.com");
        }
    }
}