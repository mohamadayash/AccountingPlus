namespace AccountingPlusDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountRefId = c.Guid(nullable: false),
                        ControlAccountRefId = c.Guid(nullable: false),
                        AccountName = c.String(unicode: false),
                        AccountNumber = c.String(unicode: false),
                        CurrencyRefId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.AccountRefId)
                .ForeignKey("dbo.ControlAccounts", t => t.ControlAccountRefId, cascadeDelete: true)
                .ForeignKey("dbo.Currencies", t => t.CurrencyRefId, cascadeDelete: true)
                .Index(t => t.ControlAccountRefId)
                .Index(t => t.CurrencyRefId);
            
            CreateTable(
                "dbo.ControlAccounts",
                c => new
                    {
                        ControlAccountRefId = c.Guid(nullable: false),
                        ParentControlAccountRefId = c.Guid(),
                        ControlAccountName = c.String(unicode: false),
                        ControlAccountNumber = c.String(unicode: false),
                        Length = c.Int(nullable: false),
                        StructureRefId = c.Guid(),
                    })
                .PrimaryKey(t => t.ControlAccountRefId)
                .ForeignKey("dbo.ControlAccounts", t => t.ParentControlAccountRefId)
                .ForeignKey("dbo.Structures", t => t.StructureRefId)
                .Index(t => t.ParentControlAccountRefId)
                .Index(t => t.StructureRefId);
            
            CreateTable(
                "dbo.Structures",
                c => new
                    {
                        StructureRefId = c.Guid(nullable: false),
                        StructureCode = c.String(unicode: false),
                        StructureName = c.String(unicode: false),
                        SalesAccountRefId = c.Guid(nullable: false),
                        PurchaseAccountRefId = c.Guid(nullable: false),
                        CustomerAccountsRefId = c.Guid(nullable: false),
                        VendorAccountsRefId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.StructureRefId)
                .ForeignKey("dbo.ControlAccounts", t => t.CustomerAccountsRefId, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.PurchaseAccountRefId, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.SalesAccountRefId, cascadeDelete: true)
                .ForeignKey("dbo.ControlAccounts", t => t.VendorAccountsRefId, cascadeDelete: true)
                .Index(t => t.SalesAccountRefId)
                .Index(t => t.PurchaseAccountRefId)
                .Index(t => t.CustomerAccountsRefId)
                .Index(t => t.VendorAccountsRefId);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        CurrencyRefId = c.Guid(nullable: false),
                        CurrencyName = c.String(unicode: false),
                        CurrencySymbol = c.String(unicode: false),
                        CurrencyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyOperator = c.Int(nullable: false),
                        IsBaseCurrency = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CurrencyRefId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerRefId = c.Guid(nullable: false),
                        CustomerName = c.String(unicode: false),
                        AccountRefId = c.Guid(nullable: false),
                        CustomerPhone = c.String(unicode: false),
                        CustomerAddress = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.CustomerRefId)
                .ForeignKey("dbo.Accounts", t => t.AccountRefId, cascadeDelete: true)
                .Index(t => t.AccountRefId);
            
           
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        VendorRefId = c.Guid(nullable: false),
                        VendorName = c.String(unicode: false),
                        AccountRefId = c.Guid(nullable: false),
                        VendorPhone = c.String(unicode: false),
                        VendorAddress = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.VendorRefId)
                .ForeignKey("dbo.Accounts", t => t.AccountRefId, cascadeDelete: true)
                .Index(t => t.AccountRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendors", "AccountRefId", "dbo.Accounts");
            DropForeignKey("dbo.Customers", "AccountRefId", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "CurrencyRefId", "dbo.Currencies");
            DropForeignKey("dbo.Accounts", "ControlAccountRefId", "dbo.ControlAccounts");
            DropForeignKey("dbo.ControlAccounts", "StructureRefId", "dbo.Structures");
            DropForeignKey("dbo.Structures", "VendorAccountsRefId", "dbo.ControlAccounts");
            DropForeignKey("dbo.Structures", "SalesAccountRefId", "dbo.Accounts");
            DropForeignKey("dbo.Structures", "PurchaseAccountRefId", "dbo.Accounts");
            DropForeignKey("dbo.Structures", "CustomerAccountsRefId", "dbo.ControlAccounts");
            DropForeignKey("dbo.ControlAccounts", "ParentControlAccountRefId", "dbo.ControlAccounts");
            DropIndex("dbo.Vendors", new[] { "AccountRefId" });
            DropIndex("dbo.Customers", new[] { "AccountRefId" });
            DropIndex("dbo.Structures", new[] { "VendorAccountsRefId" });
            DropIndex("dbo.Structures", new[] { "CustomerAccountsRefId" });
            DropIndex("dbo.Structures", new[] { "PurchaseAccountRefId" });
            DropIndex("dbo.Structures", new[] { "SalesAccountRefId" });
            DropIndex("dbo.ControlAccounts", new[] { "StructureRefId" });
            DropIndex("dbo.ControlAccounts", new[] { "ParentControlAccountRefId" });
            DropIndex("dbo.Accounts", new[] { "CurrencyRefId" });
            DropIndex("dbo.Accounts", new[] { "ControlAccountRefId" });
            DropTable("dbo.Vendors");
            DropTable("dbo.TempControlAccounts");
            DropTable("dbo.Customers");
            DropTable("dbo.Currencies");
            DropTable("dbo.Structures");
            DropTable("dbo.ControlAccounts");
            DropTable("dbo.Accounts");
        }
    }
}
