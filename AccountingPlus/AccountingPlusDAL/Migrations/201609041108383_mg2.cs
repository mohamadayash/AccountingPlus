namespace AccountingPlusDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "CurrencyRefId", "dbo.Currencies");
            DropIndex("dbo.Accounts", new[] { "CurrencyRefId" });
            AlterColumn("dbo.Accounts", "CurrencyRefId", c => c.Guid());
            CreateIndex("dbo.Accounts", "CurrencyRefId");
            AddForeignKey("dbo.Accounts", "CurrencyRefId", "dbo.Currencies", "CurrencyRefId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "CurrencyRefId", "dbo.Currencies");
            DropIndex("dbo.Accounts", new[] { "CurrencyRefId" });
            AlterColumn("dbo.Accounts", "CurrencyRefId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Accounts", "CurrencyRefId");
            AddForeignKey("dbo.Accounts", "CurrencyRefId", "dbo.Currencies", "CurrencyRefId", cascadeDelete: true);
        }
    }
}
