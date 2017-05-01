namespace AccountingPlusDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvoiceLines",
                c => new
                    {
                        InvoiceLineRefId = c.Guid(nullable: false),
                        InvoiceRefId = c.Guid(nullable: false),
                        ProductUnitRefId = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyRefId = c.Guid(nullable: false),
                        InvoiceLineTax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceLineTaxCurr1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceLineDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceLineDiscountCurr1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceLineSubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceLineSubTotalCurr1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceLineTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceLineTotalCurr1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.InvoiceLineRefId)
                .ForeignKey("dbo.Currencies", t => t.CurrencyRefId, cascadeDelete: true)
                .ForeignKey("dbo.Invoices", t => t.InvoiceRefId, cascadeDelete: true)
                .ForeignKey("dbo.ProductUnits", t => t.ProductUnitRefId, cascadeDelete: true)
                .Index(t => t.InvoiceRefId)
                .Index(t => t.ProductUnitRefId)
                .Index(t => t.CurrencyRefId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceRefId = c.Guid(nullable: false),
                        InvoiceNumber = c.String(unicode: false),
                        PersonAccountRefId = c.Guid(nullable: false),
                        CurrencyRefId = c.Guid(nullable: false),
                        CurrencyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceDate = c.DateTime(nullable: false, precision: 0),
                        InvoiceType = c.Int(nullable: false),
                        InvoiceReference = c.String(unicode: false),
                        InvoiceDescription = c.String(unicode: false),
                        InvoiceDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceTax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceSubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.InvoiceRefId)
                .ForeignKey("dbo.Currencies", t => t.CurrencyRefId, cascadeDelete: true)
                .Index(t => t.CurrencyRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceLines", "ProductUnitRefId", "dbo.ProductUnits");
            DropForeignKey("dbo.InvoiceLines", "InvoiceRefId", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "CurrencyRefId", "dbo.Currencies");
            DropForeignKey("dbo.InvoiceLines", "CurrencyRefId", "dbo.Currencies");
            DropIndex("dbo.Invoices", new[] { "CurrencyRefId" });
            DropIndex("dbo.InvoiceLines", new[] { "CurrencyRefId" });
            DropIndex("dbo.InvoiceLines", new[] { "ProductUnitRefId" });
            DropIndex("dbo.InvoiceLines", new[] { "InvoiceRefId" });
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceLines");
        }
    }
}
