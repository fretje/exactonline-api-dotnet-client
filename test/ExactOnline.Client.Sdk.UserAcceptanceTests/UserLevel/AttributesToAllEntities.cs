using ExactOnline.Client.Models.Assets;
using ExactOnline.Client.Models.Budget;
using ExactOnline.Client.Models.Cashflow;
using ExactOnline.Client.Models.CRM;
using ExactOnline.Client.Models.Documents;
using ExactOnline.Client.Models.Financial;
using ExactOnline.Client.Models.HRM;
using ExactOnline.Client.Models.Inventory;
using ExactOnline.Client.Models.Logistics;
using ExactOnline.Client.Models.Mailbox;
using ExactOnline.Client.Models.Manufacturing;
using ExactOnline.Client.Models.Payroll;
using ExactOnline.Client.Models.Project;
using ExactOnline.Client.Models.Sales;
using ExactOnline.Client.Models.SalesEntry;
using ExactOnline.Client.Models.SalesInvoice;
using ExactOnline.Client.Models.Users;
using ExactOnline.Client.Models.VAT;
using ExactOnline.Client.Sdk.TestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExactOnline.Client.Sdk.UserAcceptanceTests.UserLevel
{
    [TestClass]
    public class AttributesToAllEntities
    {
        [TestMethod]
        [TestCategory("User Acceptance Tests")]
        public void ReadAllEntities()
        {
            var client = new TestObjectsCreator().GetClient();

            // Not supported entities
            //var printedSalesInvoiceCollection = client.For<PrintedSalesInvoice>().Top(1); // Does only support post		
            //var salesItemPriceCollection = client.For<SalesItemPrice>().Top(1); // Is a function
            //var stockPositionCollection = client.For<StockPosition>().Top(1); // Is a function

            // Read Entities
            _ = client.For<AgingOverview>().Select("AmountPayable").Top(1);
            _ = client.For<Account>().Select("ID").Top(1);
            _ = client.For<AccountClass>().Select("ID").Top(1);
            _ = client.For<Asset>().Select("ID").Top(1);
            _ = client.For<BankAccount>().Select("ID").Top(1);
            _ = client.For<Budget>().Select("ID").Top(1);
            _ = client.For<Contact>().Select("ID").Top(1);
            _ = client.For<Costcenter>().Select("ID").Top(1);
            _ = client.For<CostTransaction>().Select("ID").Top(1);
            _ = client.For<Costunit>().Select("ID").Top(1);
            _ = client.For<Division>().Select("HID").Top(1);
            _ = client.For<Client.Models.Documents.Document>().Select("ID").Top(1);
            _ = client.For<DocumentAttachment>().Select("ID").Top(1);
            _ = client.For<DocumentCategory>().Select("ID").Top(1);
            _ = client.For<DocumentType>().Select("ID").Top(1);
            _ = client.For<DocumentTypeCategory>().Select("ID").Top(1);
            _ = client.For<Employee>().Select("ID").Top(1);
            _ = client.For<ExchangeRate>().Select("ID").Top(1);
            _ = client.For<FinancialPeriod>().Select("ID").Top(1);
            _ = client.For<GLAccount>().Select("ID").Top(1);
            _ = client.For<GLClassification>().Select("ID").Top(1);
            _ = client.For<GLScheme>().Select("ID").Top(1);
            _ = client.For<Item>().Select("ID").Top(1);
            _ = client.For<ItemGroup>().Select("ID").Top(1);
            _ = client.For<Journal>().Select("ID").Top(1);
            _ = client.For<Layout>().Select("ID").Top(1);
            _ = client.For<Mailbox>().Select("ID").Top(1);
            _ = client.For<MailMessagesSent>().Select("ID").Top(1);
            _ = client.For<MailMessageAttachment>().Select("ID").Top(1);
            _ = client.For<Operation>().Select("ID").Top(1);
            _ = client.For<OperationResource>().Select("ID").Top(1);
            _ = client.For<Opportunity>().Select("ID").Top(1);
            _ = client.For<OpportunityContact>().Select("ID").Top(1);
            _ = client.For<OutstandingInvoicesOverview>().Select("CurrencyCode").Top(1);
            _ = client.For<PaymentCondition>().Select("ID").Top(1);
            _ = client.For<PriceList>().Select("ID").Top(1);
            _ = client.For<ProductionArea>().Select("ID").Top(1);
            _ = client.For<SalesEntry>().Select("EntryID").Top(1);
            _ = client.For<SalesEntryLine>().Select("ID").Top(1);
            _ = client.For<SalesInvoice>().Select("InvoiceID").Top(1);
            _ = client.For<SalesInvoiceLine>().Select("ID").Top(1);
            _ = client.For<ShopOrder>().Select("ID").Top(1);
            _ = client.For<ShopOrderMaterialPlan>().Select("ID").Top(1);
            _ = client.For<ShopOrderRoutingStepPlan>().Select("ID").Top(1);
            _ = client.For<Return>().Select("DocumentID").Top(1);
            _ = client.For<Client.Models.Project.TimeTransaction>().Select("ID").Top(1);
            _ = client.For<Unit>().Select("ID").Top(1);
            _ = client.For<User>().Select("UserID").Top(1);
            _ = client.For<UserRole>().Select("ID").Top(1);
            _ = client.For<VATCode>().Select("Code").Top(1);
            _ = client.For<Warehouse>().Select("ID").Top(1);
            _ = client.For<Workcenter>().Select("ID").Top(1);
        }
    }
}
