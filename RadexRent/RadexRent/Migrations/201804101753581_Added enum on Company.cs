namespace RadexRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedenumonCompany : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CarModels", "Company", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CarModels", "Company", c => c.String());
        }
    }
}
