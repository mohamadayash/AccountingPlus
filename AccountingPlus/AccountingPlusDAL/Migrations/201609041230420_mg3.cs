namespace AccountingPlusDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Currencies", "StructureRefId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Currencies", "CurrencyOperator", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Currencies", "CurrencyOperator", c => c.Int(nullable: false));
            DropColumn("dbo.Currencies", "StructureRefId");
        }
    }
}
