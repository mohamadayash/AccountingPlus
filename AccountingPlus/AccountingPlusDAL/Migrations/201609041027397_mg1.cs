namespace AccountingPlusDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Structures", "CustomerAccountsRefId", "dbo.ControlAccounts");
            DropForeignKey("dbo.Structures", "PurchaseAccountRefId", "dbo.Accounts");
            DropForeignKey("dbo.Structures", "SalesAccountRefId", "dbo.Accounts");
            DropForeignKey("dbo.Structures", "VendorAccountsRefId", "dbo.ControlAccounts");
            DropIndex("dbo.Structures", new[] { "SalesAccountRefId" });
            DropIndex("dbo.Structures", new[] { "PurchaseAccountRefId" });
            DropIndex("dbo.Structures", new[] { "CustomerAccountsRefId" });
            DropIndex("dbo.Structures", new[] { "VendorAccountsRefId" });
            AlterColumn("dbo.Structures", "SalesAccountRefId", c => c.Guid());
            AlterColumn("dbo.Structures", "PurchaseAccountRefId", c => c.Guid());
            AlterColumn("dbo.Structures", "CustomerAccountsRefId", c => c.Guid());
            AlterColumn("dbo.Structures", "VendorAccountsRefId", c => c.Guid());
            CreateIndex("dbo.Structures", "SalesAccountRefId");
            CreateIndex("dbo.Structures", "PurchaseAccountRefId");
            CreateIndex("dbo.Structures", "CustomerAccountsRefId");
            CreateIndex("dbo.Structures", "VendorAccountsRefId");
            AddForeignKey("dbo.Structures", "CustomerAccountsRefId", "dbo.ControlAccounts", "ControlAccountRefId");
            AddForeignKey("dbo.Structures", "PurchaseAccountRefId", "dbo.Accounts", "AccountRefId");
            AddForeignKey("dbo.Structures", "SalesAccountRefId", "dbo.Accounts", "AccountRefId");
            AddForeignKey("dbo.Structures", "VendorAccountsRefId", "dbo.ControlAccounts", "ControlAccountRefId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Structures", "VendorAccountsRefId", "dbo.ControlAccounts");
            DropForeignKey("dbo.Structures", "SalesAccountRefId", "dbo.Accounts");
            DropForeignKey("dbo.Structures", "PurchaseAccountRefId", "dbo.Accounts");
            DropForeignKey("dbo.Structures", "CustomerAccountsRefId", "dbo.ControlAccounts");
            DropIndex("dbo.Structures", new[] { "VendorAccountsRefId" });
            DropIndex("dbo.Structures", new[] { "CustomerAccountsRefId" });
            DropIndex("dbo.Structures", new[] { "PurchaseAccountRefId" });
            DropIndex("dbo.Structures", new[] { "SalesAccountRefId" });
            AlterColumn("dbo.Structures", "VendorAccountsRefId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Structures", "CustomerAccountsRefId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Structures", "PurchaseAccountRefId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Structures", "SalesAccountRefId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Structures", "VendorAccountsRefId");
            CreateIndex("dbo.Structures", "CustomerAccountsRefId");
            CreateIndex("dbo.Structures", "PurchaseAccountRefId");
            CreateIndex("dbo.Structures", "SalesAccountRefId");
            AddForeignKey("dbo.Structures", "VendorAccountsRefId", "dbo.ControlAccounts", "ControlAccountRefId", cascadeDelete: true);
            AddForeignKey("dbo.Structures", "SalesAccountRefId", "dbo.Accounts", "AccountRefId", cascadeDelete: true);
            AddForeignKey("dbo.Structures", "PurchaseAccountRefId", "dbo.Accounts", "AccountRefId", cascadeDelete: true);
            AddForeignKey("dbo.Structures", "CustomerAccountsRefId", "dbo.ControlAccounts", "ControlAccountRefId", cascadeDelete: true);
        }
    }
}
