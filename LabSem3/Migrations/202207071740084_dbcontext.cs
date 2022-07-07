namespace LabSem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbcontext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Thumbnail", c => c.String());
            AddColumn("dbo.TypeComplaints", "TypeRole", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TypeComplaints", "TypeRole");
            DropColumn("dbo.Users", "Thumbnail");
        }
    }
}
