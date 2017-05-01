namespace AccountingPlusDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryRefId = c.Guid(nullable: false),
                        CategoryName = c.String(unicode: false),
                        CategoryCode = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.CategoryRefId);
            
            CreateTable(
                "dbo.ProductUnits",
                c => new
                    {
                        ProductRefId = c.Guid(nullable: false),
                        ProductName = c.String(unicode: false),
                        ProductCode = c.String(unicode: false),
                        StructureRefId = c.Guid(),
                        CategoryRefId = c.Guid(),
                        UnitRefId = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyRefId = c.Guid(nullable: false),
                        ProductSalesAccountRefId = c.Guid(),
                        ProductPurchaseAccountRefId = c.Guid(),
                    })
                .PrimaryKey(t => t.ProductRefId)
                .ForeignKey("dbo.Categories", t => t.CategoryRefId)
                .ForeignKey("dbo.Currencies", t => t.CurrencyRefId, cascadeDelete: true)
                .ForeignKey("dbo.Structures", t => t.StructureRefId)
                .ForeignKey("dbo.Units", t => t.UnitRefId, cascadeDelete: true)
                .Index(t => t.StructureRefId)
                .Index(t => t.CategoryRefId)
                .Index(t => t.UnitRefId)
                .Index(t => t.CurrencyRefId);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        UnitRefId = c.Guid(nullable: false),
                        UnitName = c.String(unicode: false),
                        UnitCode = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.UnitRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductUnits", "UnitRefId", "dbo.Units");
            DropForeignKey("dbo.ProductUnits", "StructureRefId", "dbo.Structures");
            DropForeignKey("dbo.ProductUnits", "CurrencyRefId", "dbo.Currencies");
            DropForeignKey("dbo.ProductUnits", "CategoryRefId", "dbo.Categories");
            DropIndex("dbo.ProductUnits", new[] { "CurrencyRefId" });
            DropIndex("dbo.ProductUnits", new[] { "UnitRefId" });
            DropIndex("dbo.ProductUnits", new[] { "CategoryRefId" });
            DropIndex("dbo.ProductUnits", new[] { "StructureRefId" });
            DropTable("dbo.Units");
            DropTable("dbo.ProductUnits");
            DropTable("dbo.Categories");
        }
    }
}
