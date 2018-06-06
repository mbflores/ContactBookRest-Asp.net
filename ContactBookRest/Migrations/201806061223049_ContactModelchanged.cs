namespace ContactBookRest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactModelchanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "FirstName", c => c.String());
            AlterColumn("dbo.Contacts", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "LastName", c => c.Int(nullable: false));
            AlterColumn("dbo.Contacts", "FirstName", c => c.Int(nullable: false));
        }
    }
}
