using Expense.Core;
using Expense.Web.MVC4.Controllers;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.FluentMVCTesting;

namespace Expense.Web.MVC4Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        #region Index
        [TestMethod]
        public void HomeControler_WhenGetIsSentToIndexAction_ShouldReanderDefaultIndexView()
        {
            var repo = new Mock<IExpenseRepository>();
            var sut = new HomeController(repo.Object);

            sut.WithCallTo(x => x.Index())
                .ShouldRenderDefaultView();
        }

        //[Test]
        //public void HomeController_WhenProvidedInvalidID_ShouldReturn404Status()
        //{
        //    var sut = new HomeController();
        //    sut.WithCallTo(x => x.Index(5))
        //        .ShouldGiveHttpStatus(HttpStatusCode.NotFound);
        //}

        //[Test]
        //public void HomeController_WhenProvidedValidID_ShouldReturnValidExpenseJournal()
        //{
        //    var sut = new HomeController();
        //    sut.WithCallTo(x => x.Index(6))
        //        .ShouldRenderDefaultView()
        //        .WithModel<ExpenseJournalViewModel>(x => x.Amount == "50" && x.ExpneseDate == "01/01/2016");
        //}



        #endregion

        #region Contact

        [TestMethod]
        public void HomeController_WhenGetContactMe_ShoudlRedirectToYahoo()
        {
            var sut = new HomeController();
            sut.WithCallTo(x => x.ContactMe())
                .ShouldRedirectTo("http://yahoo.com");
        }

        #endregion 


        [TestMethod]
        public void HomeIndexView_WhenProvidedValidID_ShoulReanderAmount()
        {
            ////var sut = new Cus 
            //var model = new ExpenseJournalViewModel
            //{
            //    Amount = "50",
            //    ExpneseDate = new DateTime(01 / 01 / 2016)
            //};

            //var html = sut.re
            ////sut.RenderAsHtml() >> not found
            //html.get

            //sut.WithCallTo(x => x.Index(6))
            //    .ShouldRenderDefaultView()
            //    .WithModel<ExpenseJournalViewModel>(x => x.Amount == "50" && x.ExpneseDate == new DateTime(01 / 01 / 2016));
        }

        #region Add Expense
        //[Test]
        //public void Should_redirect_to_home_on_sucessful_expense_save()
        //{
        //    var repo = new Mock<IExpenseRepository>();
        //    var sut = new HomeController(repo.Object);

        //    ExpenseJournalViewModel ex = new ExpenseJournalViewModel();
        //    ex.Amount = "100.99";
        //    ex.Category = "Grocessry";
        //    ex.ExpneseDate = "09/30/2016";
        //    ex.Merchant = "PNS";

        //    //var v = sut.AddExpense(ex) as ViewResult;
        //    //v.View.
        //    //Render
        //    //var str = sut.WithCallTo(x => x.AddExpense(ex))
        //    //     .ToString();

        //    Assert.Fail();
        //}

        #endregion 
    }
}

