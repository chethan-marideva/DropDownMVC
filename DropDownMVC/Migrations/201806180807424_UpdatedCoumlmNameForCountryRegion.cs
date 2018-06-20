namespace DropDownMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedCoumlmNameForCountryRegion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Countries", "CountryNameEnglish", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Regions", "RegionNameEnglish", c => c.String(nullable: false));
            DropColumn("dbo.Countries", "CountryEnglishName");
            DropColumn("dbo.Regions", "RegionEnglishName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Regions", "RegionEnglishName", c => c.String(nullable: false));
            AddColumn("dbo.Countries", "CountryEnglishName", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Regions", "RegionNameEnglish");
            DropColumn("dbo.Countries", "CountryNameEnglish");
        }
    }
}
