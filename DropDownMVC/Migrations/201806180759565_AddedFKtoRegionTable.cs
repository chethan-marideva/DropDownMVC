namespace DropDownMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFKtoRegionTable : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Regions", "Iso3");
            AddForeignKey("dbo.Regions", "Iso3", "dbo.Countries", "Iso3", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Regions", "Iso3", "dbo.Countries");
            DropIndex("dbo.Regions", new[] { "Iso3" });
        }
    }
}
