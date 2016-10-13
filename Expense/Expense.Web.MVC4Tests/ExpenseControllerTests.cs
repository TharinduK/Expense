using Expense.Core;
using Expense.Web.MVC4.Controllers;
using Expense.Web.MVC4.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Expense.Web.MVC4Tests
{
    [TestClass]
    public class ExpenseControllerTests
    {
        private Mock<IExpenseRepository> _repo;
        private HomeController.ExpenseController _sut;

        [TestInitialize]
        public void SetUpExpenseController()
        {
            _repo = new Mock<IExpenseRepository>();
            _sut = new HomeController.ExpenseController(_repo.Object);
        }

        [TestMethod]
        public void AddExpenseAllInfoCollected_WhenMissingRequiredInfo_ShouldFail()
        {
            //arrange
            var model = new ExpenseJournalViewModel();
            Assert.AreEqual(false, _sut.AllRequiredInformationCollected(model));

            model.Amount = "100.00";
            Assert.AreEqual(false, _sut.AllRequiredInformationCollected(model));

            model.Category = "Cat";
            Assert.AreEqual(false, _sut.AllRequiredInformationCollected(model));

            model.ExpneseDate = "today";
            Assert.AreEqual(false, _sut.AllRequiredInformationCollected(model));

            model = new ExpenseJournalViewModel();
            model.Merchant = "Mert";
            Assert.AreEqual(false, _sut.AllRequiredInformationCollected(model));
        }



        [TestMethod]
        public void AddExpenseAllInfoCollected_WhenCompleteRequiredInfo_ShouldPass()
        {
            //arrange
            var model = new ExpenseJournalViewModel();
            model.Amount = "100.00";
            model.Category = "Cat";
            model.ExpneseDate = "today";
            model.Merchant = "Mert";
            Assert.AreEqual(true, _sut.AllRequiredInformationCollected(model));
        }
    }
}
