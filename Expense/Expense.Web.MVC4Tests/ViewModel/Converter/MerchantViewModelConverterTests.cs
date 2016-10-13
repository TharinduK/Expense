using Microsoft.VisualStudio.TestTools.UnitTesting;
using Expense.Web.MVC4.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expense.Core;

namespace Expense.Web.MVC4.ViewModel.Tests
{
    [TestClass()]
    public class MerchantViewModelConverterTests
    {
        [TestMethod()]
        public void ToMerchantViewModel_withIsActive()
        {
            string expectedName = "Store Name";
            string expectedAlias = "stAlias";
            string expectedNotes = "notes and more notes";
            bool modelIsActive = true;
            string expectedStatus = "Active";
            Merchant merch = new Merchant(expectedName, expectedAlias, expectedNotes, modelIsActive);

            var actual = MerchantViewModelConverter.ToMerchantViewModel(merch);

            Assert.AreEqual(expectedAlias.ToUpper(), actual.Alias);//merchant converts alias to upper to be case insensitive
            Assert.AreEqual(expectedName, actual.Name);
            Assert.AreEqual(expectedNotes, actual.Notes);
            Assert.AreEqual(expectedStatus, actual.Status);
        }

        [TestMethod()]
        public void ToMerchantViewModel_withIsNotActive()
        {
            string expectedName = "Store Name";
            string expectedAlias = "stAlias";
            string expectedNotes = "notes and more notes";
            bool modelIsActive = false;
            string expectedStatus = "Inactive";
            Merchant merch = new Merchant(expectedName, expectedAlias, expectedNotes, modelIsActive);

            var actual = MerchantViewModelConverter.ToMerchantViewModel(merch);

            Assert.AreEqual(expectedAlias.ToUpper(), actual.Alias);
            Assert.AreEqual(expectedName, actual.Name);
            Assert.AreEqual(expectedNotes, actual.Notes);
            Assert.AreEqual(expectedStatus, actual.Status);
        }

        [TestMethod()]
        public void ToMerchant_withActive()
        {
            string expectedName = "Store Name";
            string expectedAlias = "stAlias";
            string expectedNotes = "notes and more notes";
            string vmStatus = "Active";
            bool expectedStatus = true;

            MerchantViewModel vm = new MerchantViewModel
            {
                Name = expectedName,
                Alias = expectedAlias,
                Notes = expectedNotes,
                Status = vmStatus
            };

            var actual = MerchantViewModelConverter.ToMerchant(vm);

            Assert.AreEqual(expectedAlias.ToUpper(), actual.MerchantAlias);
            Assert.AreEqual(expectedName, actual.MerchantName);
            Assert.AreEqual(expectedNotes, actual.Notes);
            Assert.AreEqual(expectedStatus, actual.IsActive);
        }

        [TestMethod()]
        public void ToMerchant_withInactive()
        {
            string expectedName = "Store Name";
            string expectedAlias = "stAlias";
            string expectedNotes = "notes and more notes";
            string vmStatus = "Inactive";
            bool expectedStatus = false;

            MerchantViewModel vm = new MerchantViewModel
            {
                Name = expectedName,
                Alias = expectedAlias,
                Notes = expectedNotes,
                Status = vmStatus
            };

            var actual = MerchantViewModelConverter.ToMerchant(vm);

            Assert.AreEqual(expectedAlias.ToUpper(), actual.MerchantAlias);
            Assert.AreEqual(expectedName, actual.MerchantName);
            Assert.AreEqual(expectedNotes, actual.Notes);
            Assert.AreEqual(expectedStatus, actual.IsActive);
        }
        [TestMethod()]
        public void ToMerchant_withNoStatus()
        {
            string expectedName = "Store Name";
            string expectedAlias = "stAlias";
            string expectedNotes = "notes and more notes";
            string vmStatus = "";
            bool expectedStatus = false;

            MerchantViewModel vm = new MerchantViewModel
            {
                Name = expectedName,
                Alias = expectedAlias,
                Notes = expectedNotes,
                Status = vmStatus
            };

            var actual = MerchantViewModelConverter.ToMerchant(vm);

            Assert.AreEqual(expectedAlias.ToUpper(), actual.MerchantAlias);
            Assert.AreEqual(expectedName, actual.MerchantName);
            Assert.AreEqual(expectedNotes, actual.Notes);
            Assert.AreEqual(expectedStatus, actual.IsActive);
        }
        [TestMethod()]
        public void ToMerchant_withLowerCaseActive()
        {
            string expectedName = "Store Name";
            string expectedAlias = "stAlias";
            string expectedNotes = "notes and more notes";
            string vmStatus = "active";
            bool expectedStatus = true;

            MerchantViewModel vm = new MerchantViewModel
            {
                Name = expectedName,
                Alias = expectedAlias,
                Notes = expectedNotes,
                Status = vmStatus
            };

            var actual = MerchantViewModelConverter.ToMerchant(vm);

            Assert.AreEqual(expectedAlias.ToUpper(), actual.MerchantAlias);
            Assert.AreEqual(expectedName, actual.MerchantName);
            Assert.AreEqual(expectedNotes, actual.Notes);
            Assert.AreEqual(expectedStatus, actual.IsActive);
        }
        [TestMethod()]
        public void ToMerchantViewModelCollection_with3Elemets()
        {
            List<Merchant> merchList = new List<Merchant>();
            int expectedCount = 3;

            string expectedName = "Store Name1";
            string expectedAlias = "stAlias1";
            string expectedNotes = "notes and more notes1";
            bool modelIsActive = false;
            Merchant merch = new Merchant(expectedName, expectedAlias, expectedNotes, modelIsActive);
            merchList.Add(merch);

            expectedName = "Store Name2";
            expectedAlias = "stAlias2";
            expectedNotes = "notes and more notes2";
            modelIsActive = true;
            merch = new Merchant(expectedName, expectedAlias, expectedNotes, modelIsActive);
            merchList.Add(merch);

            expectedName = "Store Name3";
            expectedAlias = "stAlias3";
            expectedNotes = "notes and more notes3";
            modelIsActive = false;
            merch = new Merchant(expectedName, expectedAlias, expectedNotes, modelIsActive);
            merchList.Add(merch);

            var actual = MerchantViewModelConverter.ToMerchantViewModelCollection(merchList);

            int actulaCount = actual.Count<MerchantViewModel>();
            Assert.AreEqual(expectedCount, actulaCount);

        }


    }
}