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

public class EntityFrameworkCoreDbContext : DbContext
{
	public EntityFrameworkCoreDbContext(DbContextOptions options)
		: base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		foreach (var type in EntityFrameworkCoreTarget.SupportedModelTypes)
		{
			var identifierName = ModelInfo.For(type).IdentifierName;
			var identifierNames = !string.IsNullOrEmpty(identifierName) ? identifierName.Split(',') : null;
			if (identifierNames?.Length > 0)
			{
				var entityTypeBuilder = modelBuilder.Entity(type);
				entityTypeBuilder.HasKey(identifierNames);
				foreach (var identifier in identifierNames)
				{
					entityTypeBuilder.Property(identifier).ValueGeneratedNever();
				}
			}
		}

		//modelBuilder.Entity<ShopOrderMaterialPlanDetail>().OwnsOne(d => d.Calculator, c =>
		//{
		//	c.OwnsOne(d => d.FixedCalculator);
		//	c.Navigation(e => e.FixedCalculator).IsRequired();
		//	c.OwnsOne(d => d.MaterialsPerPieceCalculator);
		//	c.Navigation(e => e.MaterialsPerPieceCalculator).IsRequired();
		//	c.OwnsOne(d => d.PiecesPerMaterialCalculator);
		//	c.Navigation(e => e.PiecesPerMaterialCalculator).IsRequired();
		//	c.OwnsOne(d => d.BarCalculator);
		//	c.Navigation(e => e.BarCalculator).IsRequired();
		//	c.OwnsOne(d => d.SheetCalculator);
		//	c.Navigation(e => e.SheetCalculator).IsRequired();
		//	c.OwnsOne(d => d.CoilWireLengthCalculator);
		//	c.Navigation(e => e.CoilWireLengthCalculator).IsRequired();
		//	c.OwnsOne(d => d.CoilWireWeightCalculator);
		//	c.Navigation(e => e.CoilWireWeightCalculator).IsRequired();
		//	c.OwnsOne(d => d.VolumeCalculator);
		//	c.Navigation(e => e.VolumeCalculator).IsRequired();
		//});
		//modelBuilder.Entity<ShopOrderMaterialPlanDetail>().Navigation(d => d.Calculator).IsRequired();
		//modelBuilder.Entity<BatchNumber>().OwnsMany(b => b.StorageLocations);
		//modelBuilder.Entity<BatchNumber>().OwnsMany(b => b.Warehouses);

		modelBuilder.Entity<ShopOrderMaterialPlanDetail>().Ignore(a => a.Calculator);
		modelBuilder.Entity<BatchNumber>().Ignore(a => a.StorageLocations);
		modelBuilder.Entity<BatchNumber>().Ignore(a => a.Warehouses);

		// remove foreign key constraints
		modelBuilder.Entity<AbsenceRegistration>().Ignore(a => a.AbsenceRegistrationTransactions);
		modelBuilder.Entity<Account>().Ignore(a => a.BankAccounts);
		modelBuilder.Entity<BankEntry>().Ignore(a => a.BankEntryLines);
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
