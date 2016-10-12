using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Expense.Core;
using Expense.Core.Exceptions;

namespace Expense.CoreTests.Unit
{
    [TestClass]
    public class MerchantTests
    {
        private FakeExpenseRepository _repository = new FakeExpenseRepository();
        private IApplicationLogger _log = new FakeApplicationLogger();

        [TestInitialize]
        public void Init()
        {
            _repository.Merchants.Add("PNS".ToUpper(), new Merchant("PNS", "PNS"));
            _repository.Merchants.Add("WF".ToUpper(), new Merchant("Wholefood", "WF"));
            _repository.Merchants.Add("WalMart".ToUpper(), new Merchant("WalMart", "WalMart"));
            _repository.Merchants.Add("AMC".ToUpper(), new Merchant("AMC", "AMC"));
            _repository.Merchants.Add("Copps".ToUpper(), new Merchant("Copps", "Copps"));
            
        }

        #region AddMerchant
        [TestMethod]
        public void AddMerchant_WhenValidInput_ShouldAddSucessfully()
        {
            string merchantName = "test_name";
            string merchantAlias = "t";
            bool merchantStatus = true;
            string merchantNotes = "test note";
            var expectedMerchant = new Merchant(merchantName, merchantAlias, merchantNotes, merchantStatus);

            var merch = new AddMerchantTransaction(_repository, _log, merchantName, merchantAlias, merchantNotes, merchantStatus);
            merch.Execute();

            Assert.IsTrue(merch.WasExecutionSucessfull, "adding merchant was not successful");
            Assert.IsTrue(_repository.Merchants.ContainsKey(expectedMerchant.MerchantAlias));
        }

        [TestMethod]
        public void AddMerchant_WhenExistingAlias_ShouldFailAdding()
        {
            string merchantName = "pick and save";
            string merchantAlias = "PNS";
            bool merchantStatus = true;
            string merchantNotes = "PNS test note";
            var expectedMerchant = new Merchant(merchantName, merchantAlias, merchantNotes, merchantStatus);

            var merch = new AddMerchantTransaction(_repository, _log, merchantName, merchantAlias, merchantNotes, merchantStatus);
            merch.Execute();

            Assert.IsFalse(merch.WasExecutionSucessfull);
        }
        [TestMethod]
        public void AddMerchant_WhenDifferentCaseExistingAlias_ShouldFailAdding()
        {
            string merchantName = "pick and save";
            string merchantAlias = "pnS";
            bool merchantStatus = true;
            string merchantNotes = "PNS test note";
            var expectedMerchant = new Merchant(merchantName, merchantAlias, merchantNotes, merchantStatus);

            var merch = new AddMerchantTransaction(_repository, _log, merchantName, merchantAlias, merchantNotes, merchantStatus);
            merch.Execute();

            Assert.IsFalse(merch.WasExecutionSucessfull);
        }
        #endregion

        #region Get Merchant Test

        [TestMethod]
        public void GetMerchant_WhenProvidedValidAlias_ShouldReturnMerchangeFromRepository()
        {
            string name = "Metro Market";
            string alias = "Metro";
            _repository.Merchants.Add("Metro".ToUpper(), new Merchant(name, alias));

            var tran = new GetMerchantTransaction(_repository, _log, alias);
            tran.Execute();
            var wasSucessfull = tran.WasExecutionSucessfull;

            Assert.AreEqual(true, wasSucessfull);
            Assert.AreEqual(alias.ToUpper(), tran.Result.MerchantAlias);
            Assert.AreEqual(name, tran.Result.MerchantName);
        }

        [TestMethod]
        public void GetMerchant_WhenProvidedInvlidAlias_ShouldSucessedAndReturnNull()
        {
            string alias = "Metro2";

            var tran = new GetMerchantTransaction(_repository, _log, alias);
            tran.Execute();
            var wasSucessfull = tran.WasExecutionSucessfull;

            Assert.AreEqual(false, wasSucessfull);
            Assert.AreEqual(null, tran.Result);
        }

        #endregion 
      
        #region Get All Merchants
        [TestMethod]
        public void GetAllMerchants_Sucessful()
        {
            var merchTran = new GetAllMerchantsTransaction(_repository, _log);
            var expected = _repository.Merchants;

            merchTran.Execute();
            var actual = merchTran.Results;

            Assert.IsTrue(merchTran.WasExecutionSucessfull);
            foreach (var actualMerch in actual)
            {
                if (expected.ContainsKey(actualMerch.MerchantAlias))
                {
                    var expectedMerch = expected[actualMerch.MerchantAlias];
                    Assert.AreEqual(expectedMerch, actualMerch);
                }
                else
                {
                    Assert.Fail($"Unexpected {actualMerch.MerchantAlias} merchant ");
                }
            }
        }
        #endregion

        #region Update Merchant

        [TestMethod]
        public void UpdateMerchant_WhenNotesUpdated_ShouldSucessfullyUpdate()
        {
            //arrange
            var merchName = "Walgreens";
            var merchAlias = "wg";
            var merchNotes = "The WG in Silverspring";
            var merchIsActive = true;
            _repository.Merchants.Add(merchAlias.ToUpper(), new Merchant(merchName, merchAlias, merchNotes, merchIsActive));

            merchNotes += "New Note Line";
            var expectedMerch = new Merchant(merchName, merchAlias, merchNotes, merchIsActive);

            //act
            var merchTran = new UpdateMerchantTransaction(_repository, _log, expectedMerch);
            merchTran.Execute();

            Assert.IsTrue(merchTran.WasExecutionSucessfull);
            //assert
            if (_repository.Merchants.ContainsKey(merchAlias.ToUpper()))
            {
                var actualMerch = _repository.Merchants[merchAlias.ToUpper()];
                Assert.AreEqual(expectedMerch, actualMerch);
            }
            else
            {
                Assert.Fail($"{merchAlias} merchant not found");
            }

        }

        #endregion 
    }
}
