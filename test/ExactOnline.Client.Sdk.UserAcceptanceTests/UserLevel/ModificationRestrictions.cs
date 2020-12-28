using ExactOnline.Client.Models.Financial;
using ExactOnline.Client.Sdk.TestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ExactOnline.Client.Sdk.UserAcceptanceTests.UserLevel
{
    [TestClass]
    public class ModificationRestrictions
    {
        [TestMethod]
        [TestCategory("User Acceptance Tests")]
        public void ModificationRestrictions_Succeed()
        {
            var client = new TestObjectsCreator().GetClient();

            // Create
            var newJournal = new Journal { Description = "New Journal" };
            try { client.For<Journal>().Insert(ref newJournal); throw new Exception(); } catch { }

            // Update
            var journal = client.For<Journal>().Top(1).Select("ID").Get().First();
            journal.Description = "Test Description";
            try { client.For<Journal>().Update(journal); throw new Exception(); } catch { }

            // Delete
            try { client.For<Journal>().Delete(journal); throw new Exception(); } catch { }
        }
    }
}
