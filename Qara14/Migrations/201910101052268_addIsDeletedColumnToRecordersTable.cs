namespace Qara14.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIsDeletedColumnToRecordersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recorders", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recorders", "IsDeleted");
        }
    }
}
