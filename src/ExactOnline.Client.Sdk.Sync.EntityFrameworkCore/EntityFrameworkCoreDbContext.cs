using ExactOnline.Client.Models.Activities;
using ExactOnline.Client.Models.CRM;
using ExactOnline.Client.Models.FinancialTransaction;
using ExactOnline.Client.Models.GeneralJournalEntry;
using ExactOnline.Client.Models.HRM;
using ExactOnline.Client.Models.Inventory;
using ExactOnline.Client.Models.Logistics;
using ExactOnline.Client.Models.Manufacturing;
using ExactOnline.Client.Models.Project;
using ExactOnline.Client.Models.Purchase;
using ExactOnline.Client.Models.PurchaseEntry;
using ExactOnline.Client.Models.PurchaseOrder;
using ExactOnline.Client.Models.SalesEntry;
using ExactOnline.Client.Models.SalesInvoice;
using ExactOnline.Client.Models.SalesOrder;
using ExactOnline.Client.Models.Subscription;
using ExactOnline.Client.Models.Users;
using ExactOnline.Client.Models.VAT;
using Microsoft.EntityFrameworkCore;
using Task = ExactOnline.Client.Models.Activities.Task;

namespace ExactOnline.Client.Sdk.Sync.EntityFrameworkCore;

public class EntityFrameworkCoreDbContext(DbContextOptions options) : DbContext(options)
{
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		foreach (var type in EntityFrameworkCoreTarget.SupportedModelTypes)
		{
			// set the key's according to the ModelInfo
			var entityTypeBuilder = modelBuilder.Entity(type);
			var identifierName = ModelInfo.For(type).IdentifierName;
			var identifierNames = !string.IsNullOrEmpty(identifierName) ? identifierName.Split(',') : null;
			if (identifierNames?.Length > 0)
			{
				entityTypeBuilder.HasKey(identifierNames);
				foreach (var identifier in identifierNames)
				{
					entityTypeBuilder.Property(identifier).ValueGeneratedNever();
				}
			}

			// set a default value for non nullable fields
			foreach (var prop in entityTypeBuilder.Metadata.GetProperties())
			{
				if (!prop.IsNullable && !prop.IsKey() && prop.PropertyInfo is not null)
				{
					prop.SetDefaultValue(Activator.CreateInstance(prop.PropertyInfo.PropertyType));
				}
			}
		}

		// remove foreign key constraints
		modelBuilder.Entity<AbsenceRegistration>().Ignore(a => a.AbsenceRegistrationTransactions);
		modelBuilder.Entity<Account>().Ignore(a => a.BankAccounts);
		modelBuilder.Entity<BankEntry>().Ignore(a => a.BankEntryLines);
		modelBuilder.Entity<BatchNumber>().Ignore(a => a.StorageLocations);
		modelBuilder.Entity<BatchNumber>().Ignore(a => a.Warehouses);
		modelBuilder.Entity<CashEntry>().Ignore(a => a.CashEntryLines);
		modelBuilder.Entity<CommunicationNote>().Ignore(a => a.Attachments);
		modelBuilder.Entity<Complaint>().Ignore(a => a.Attachments);
		modelBuilder.Entity<DivisionClassName>().Ignore(a => a.DivisionClasses);
		modelBuilder.Entity<DivisionClassValue>().Ignore(a => a.Class_01);
		modelBuilder.Entity<DivisionClassValue>().Ignore(a => a.Class_02);
		modelBuilder.Entity<DivisionClassValue>().Ignore(a => a.Class_03);
		modelBuilder.Entity<DivisionClassValue>().Ignore(a => a.Class_04);
		modelBuilder.Entity<DivisionClassValue>().Ignore(a => a.Class_05);
		modelBuilder.Entity<Event>().Ignore(a => a.Attachments);
		modelBuilder.Entity<GeneralJournalEntry>().Ignore(a => a.GeneralJournalEntryLines);
		modelBuilder.Entity<GoodsDelivery>().Ignore(a => a.GoodsDeliveryLines);
		modelBuilder.Entity<GoodsDeliveryLine>().Ignore(a => a.BatchNumbers);
		modelBuilder.Entity<GoodsDeliveryLine>().Ignore(a => a.SerialNumbers);
		modelBuilder.Entity<GoodsReceipt>().Ignore(a => a.GoodsReceiptLines);
		modelBuilder.Entity<GoodsReceiptLine>().Ignore(a => a.BatchNumbers);
		modelBuilder.Entity<GoodsReceiptLine>().Ignore(a => a.SerialNumbers);
		modelBuilder.Entity<ItemAssortment>().Ignore(a => a.Properties);
		modelBuilder.Entity<Project>().Ignore(a => a.BudgetedHoursPerHourType);
		modelBuilder.Entity<Project>().Ignore(a => a.InvoiceTerms);
		modelBuilder.Entity<Project>().Ignore(a => a.ProjectRestrictionEmployees);
		modelBuilder.Entity<Project>().Ignore(a => a.ProjectRestrictionItems);
		modelBuilder.Entity<Project>().Ignore(a => a.ProjectRestrictionRebillings);
		modelBuilder.Entity<PurchaseEntry>().Ignore(a => a.PurchaseEntryLines);
		modelBuilder.Entity<PurchaseInvoice>().Ignore(a => a.PurchaseInvoiceLines);
		modelBuilder.Entity<PurchaseOrder>().Ignore(a => a.PurchaseOrderLines);
		modelBuilder.Entity<Quotation>().Ignore(a => a.QuotationLines);
		modelBuilder.Entity<SalesEntry>().Ignore(a => a.SalesEntryLines);
		modelBuilder.Entity<SalesInvoice>().Ignore(a => a.SalesInvoiceLines);
		modelBuilder.Entity<SalesOrder>().Ignore(a => a.SalesOrderLines);
		modelBuilder.Entity<ServiceRequest>().Ignore(a => a.Attachments);
		modelBuilder.Entity<ShopOrder>().Ignore(a => a.SalesOrderLines);
		modelBuilder.Entity<ShopOrder>().Ignore(a => a.ShopOrderMaterialPlans);
		modelBuilder.Entity<ShopOrder>().Ignore(a => a.ShopOrderRoutingStepPlans);
		modelBuilder.Entity<ShopOrderMaterialPlanDetail>().Ignore(a => a.Calculator);
		modelBuilder.Entity<ShopOrderMaterialPlanDetail>().Ignore(a => a.StockLocations);
		modelBuilder.Entity<ShopOrderRoutingStepPlan>().Ignore(s => s.TimeTransactions);
		modelBuilder.Entity<StockCount>().Ignore(a => a.StockCountLines);
		modelBuilder.Entity<StockCountLine>().Ignore(a => a.SerialNumbers);
		modelBuilder.Entity<StockCountLine>().Ignore(a => a.BatchNumbers);
		modelBuilder.Entity<Subscription>().Ignore(a => a.SubscriptionLines);
		modelBuilder.Entity<Subscription>().Ignore(a => a.SubscriptionRestrictionEmployees);
		modelBuilder.Entity<Subscription>().Ignore(a => a.SubscriptionRestrictionItems);
		modelBuilder.Entity<Task>().Ignore(a => a.Attachments);
		modelBuilder.Entity<Transaction>().Ignore(a => a.TransactionLines);
		modelBuilder.Entity<User>().Ignore(a => a.UserRoles);
		modelBuilder.Entity<User>().Ignore(a => a.UserRolesPerDivision);
		modelBuilder.Entity<VATCode>().Ignore(a => a.VATPercentages);
		modelBuilder.Entity<WarehouseTransfer>().Ignore(a => a.WarehouseTransferLines);
	}
}
