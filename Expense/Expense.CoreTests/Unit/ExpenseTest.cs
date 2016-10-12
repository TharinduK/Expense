using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Expense.Core;
using System.Collections.Generic;

namespace Expense.CoreTests.Unit
{
    [TestClass]
    public class ExpenseTest
    {
        private FakeExpenseRepository _repository;
        private FakeApplicationLogger _applicationLog;

        [TestInitialize]
        public void Init()
        {
            _applicationLog = new FakeApplicationLogger();

            _repository = new FakeExpenseRepository();
            _repository.Merchants.Add("PNS", new Merchant("PNS", "PNS"));
            _repository.Merchants.Add("WF", new Merchant("WF", "Wholefood"));
            _repository.Merchants.Add("WalMart", new Merchant("WalMart", "WalMart"));
            _repository.Merchants.Add("AMC", new Merchant("AMC", "AMC"));
            _repository.Merchants.Add("Copps", new Merchant("Copps", "Copps"));

            _repository.Categories.Add("GROSSARY");
            _repository.Categories.Add("ENTERTAINMENT");
        }

        #region Add Expense Test
        [TestMethod]
        public void AddExpences_WhenAddingValidExpense_ShouldBeAbleToAddToRepository()
        {
            //arr
            var amount = 100.50M;
            var date = new DateTime(2016, 08, 20);
            var merchant = "PNS";
            var category = "GROSSARY";

            var exp = new AddExpenseTransaction(amount, date, merchant, category, _repository);
            var wassucessfull = exp.Execute();
            
            ExpenseJournal ej = _repository.Expenses.Find(e => e.ID == exp.ExpenseJournalId);
            Assert.IsTrue(wassucessfull);
            Assert.IsTrue(ej != null, "Expense was not saved");
            Assert.AreEqual(amount, ej.Amount);
            Assert.AreEqual(date, ej.ExpneseDate);
            Assert.AreEqual(category, ej.Category);
            Assert.AreEqual(merchant.ToUpper(), ej.Merchant);
        }

        [TestMethod]
        public void AddExpences_WhenAddingValidExpenseLowercaseCategory_ShouldBeAbleToAddToRepository()
        {
            //arr
            var amount = 100.50M;
            var date = new DateTime(2016, 08, 20);
            var merchant = "PNS";
            var category = "grossary";

            var exp = new AddExpenseTransaction(amount, date, merchant, category, _repository);
            var wassucessfull = exp.Execute();

            ExpenseJournal ej = _repository.Expenses.Find(e => e.ID == exp.ExpenseJournalId);
            Assert.IsTrue(wassucessfull);
            Assert.IsTrue(ej != null, "Expense was not saved");
            Assert.AreEqual(amount, ej.Amount);
            Assert.AreEqual(date, ej.ExpneseDate);
            Assert.AreEqual(category.ToUpper(), ej.Category);
            Assert.AreEqual(merchant.ToUpper(), ej.Merchant);
        }

        [TestMethod]
        public void AddExpences_WhenAddingValidExpenseLowercaseMerchant_ShouldBeAbleToAddToRepository()
        {
            //arr
            var amount = 100.50M;
            var date = new DateTime(2016, 08, 20);
            var merchant = "pns";
            var category = "GROSSARY";

            var exp = new AddExpenseTransaction(amount, date, merchant, category, _repository);
            var wassucessfull = exp.Execute();

            ExpenseJournal ej = _repository.Expenses.Find(e => e.ID == exp.ExpenseJournalId);
            Assert.IsTrue(wassucessfull);
            Assert.IsTrue(ej != null, "Expense was not saved");
            Assert.AreEqual(amount, ej.Amount);
            Assert.AreEqual(date, ej.ExpneseDate);
            Assert.AreEqual(category, ej.Category);
            Assert.AreEqual(merchant.ToUpper(), ej.Merchant);
        }

        [TestMethod]
        public void AddExpense_WhenAddingADuplicateExpnese_ShouldSucessfullyAddToRepository()
        {
            //arr
            var amount = 100.50M;
            var date = new DateTime(2016, 08, 20);
            var merchant = "PNS";
            var category = "GROSSARY";
            var expectedCount = 2;
            _repository.Expenses.Add(new ExpenseJournal(amount, date, merchant, category));

            //act
            var exp = new AddExpenseTransaction(amount, date, merchant, category, _repository);
            var wassucessfull = exp.Execute();

            int count = 0;
            foreach (var ej in _repository.Expenses)
            {
                if (ej.Amount == amount &&
                                            ej.Category == category &&
                                            ej.ExpneseDate == date &&
                                            ej.Merchant == merchant) count++;
            }

            Assert.IsTrue(wassucessfull);
            Assert.AreEqual(expectedCount, count);
        }

        //Edge test
        [TestMethod]
        public void AddExpense_WhenAddingExpencesFutureDates_ShouldSucessfullyAddToRepository()
        {
            //arr
            var amount = 100.50M;
            var date = DateTime.Now.AddMonths(1);
            var merchant = "PNS";
            var category = "GROSSARY";

            var exp = new AddExpenseTransaction(amount, date, merchant, category, _repository);
            var wassucessfull = exp.Execute();

            ExpenseJournal ej = _repository.Expenses.Find(e => e.ID == exp.ExpenseJournalId);
            Assert.IsTrue(wassucessfull);
            Assert.IsTrue(ej != null, "Expense was not saved");
            Assert.AreEqual(amount, ej.Amount);
            Assert.AreEqual(date, ej.ExpneseDate);
            Assert.AreEqual(category, ej.Category);
            Assert.AreEqual(merchant.ToUpper(), ej.Merchant);
        }

        [TestMethod]
        public void AddExpense_WhenAddingExpencesWithPastDates_ShouldSucessfullyAddToRepository()
        {
            //arr
            var amount = 100.50M;
            var date = DateTime.Now.AddMonths(-1);
            var merchant = "PNS";
            var category = "GROSSARY";

            var exp = new AddExpenseTransaction(amount, date, merchant, category, _repository);
            var wassucessfull = exp.Execute();

            ExpenseJournal ej = _repository.Expenses.Find(e => e.ID == exp.ExpenseJournalId);
            Assert.IsTrue(wassucessfull);
            Assert.IsTrue(ej != null, "Expense was not saved");
            Assert.AreEqual(amount, ej.Amount);
            Assert.AreEqual(date, ej.ExpneseDate);
            Assert.AreEqual(category, ej.Category);
            Assert.AreEqual(merchant.ToUpper(), ej.Merchant);
        }

        [TestMethod]
        public void AddExpense_WhenAddingNonExistingCategory_ShouldFailSave()
        {
            //arr
            var amount = 100.50M;
            var date = new DateTime(2016, 08, 20);
            var merchant = "OliveGarden";
            var category = "Food";


            var exp = new AddExpenseTransaction(amount, date, merchant, category, _repository);
            var wassucessfull = exp.Execute();

            ExpenseJournal ej = _repository.Expenses.Find(e => e.Amount == amount &&
                                            e.Category == category &&
                                            e.ExpneseDate == date &&
                                            e.Merchant == merchant);

            Assert.IsFalse(wassucessfull);
            Assert.IsTrue(ej == null, "Expense was not saved");
        }

        [TestMethod]
        public void AddExpense_WhenAddingNonExistingMerchant_ShouldFailSave()
        {
            //arr
            var amount = 100.50M;
            var date = new DateTime(2016, 08, 20);
            var merchant = "Metro";
            var category = "GROSSARY";


            var exp = new AddExpenseTransaction(amount, date, merchant, category, _repository);
            var wassucessfull = exp.Execute();

            ExpenseJournal ej = _repository.Expenses.Find(e => e.Amount == amount &&
                                            e.Category == category &&
                                            e.ExpneseDate == date &&
                                            e.Merchant == merchant);

            Assert.IsFalse(wassucessfull);
            Assert.IsTrue(ej == null, "Expense was not saved");
        }

        [TestMethod]
        public void AddExpense_WhenAddingRefunds_ShouldSucessfullyAddToRepository()
        {
            //arr
            var amount = 100.50M;
            var date = new DateTime(2016, 08, 20);
            var merchant = "PNS";
            var category = "GROSSARY";

            var exp = new AddRefundTransaction(amount, date, merchant, category, _repository);
            var wassucessfull = exp.Execute();

            ExpenseJournal ej = _repository.Expenses.Find(e => e.Amount == -amount &&
                                            e.Category == category &&
                                            e.ExpneseDate == date &&
                                            e.Merchant == merchant);
            Assert.IsTrue(wassucessfull);
            Assert.IsTrue(ej != null, "Expense was not saved");
            Assert.AreEqual(-amount, ej.Amount);
            Assert.AreEqual(date, ej.ExpneseDate);
            Assert.AreEqual(category, ej.Category);
            Assert.AreEqual(merchant.ToUpper(), ej.Merchant);
        }

        #endregion

        #region Get All Expenses Tests
        [TestMethod]
        public void GetAllExpences_WhenNoFilterIsProvided_ShouldBeAbleToRetriveAllExpencesInRepository()
        {
            //arr
            List<ExpenseJournal> expectedList = new List<ExpenseJournal>();
            expectedList.Add(new ExpenseJournal(100.5M, new DateTime(2016, 08, 20), "PNS", "GROSSARY"));
            expectedList.Add(new ExpenseJournal(10.5M, new DateTime(2015, 08, 20), "WG", "GROSSARY"));
            expectedList.Add(new ExpenseJournal(10.5M, new DateTime(2016, 08, 11), "WalMart", "ENTERTAINMENT"));
            expectedList.Add(new ExpenseJournal(20.75M, new DateTime(2016, 08, 23), "AMC", "ENTERTAINMENT"));
            expectedList.Add(new ExpenseJournal(100.5M, new DateTime(2017, 08, 20), "Copps", "GROSSARY"));
            expectedList.Add(new ExpenseJournal(100.5M, new DateTime(2016, 08, 20), "PNS", "GROSSARY"));

            foreach (var ej in expectedList) _repository.Expenses.Add(ej);

            var getEj = new GetAllExpences(_repository, _applicationLog);
            getEj.Execute();
            var wassucessfull = getEj.WasExecutionSucessfull;
                IEnumerable < ExpenseJournal> list = getEj.Results;

            //assert
            Assert.IsTrue(wassucessfull);
            int actulaCount = 0;
            foreach (var actual in list)
            {
                actulaCount++;
                var expected = expectedList.Find(e => e.Amount == actual.Amount &&
                e.Category == actual.Category && e.ExpneseDate == actual.ExpneseDate && e.Merchant == actual.Merchant);
                Assert.AreEqual(expected, actual);
            }
            Assert.AreEqual(expectedList.Count, actulaCount);
        }

        #endregion

    }
}
