namespace Qara14.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Daragas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recorders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DaragaId = c.Int(nullable: false),
                        RotbaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Daragas", t => t.DaragaId, cascadeDelete: true)
                .ForeignKey("dbo.Rotbas", t => t.RotbaId, cascadeDelete: true)
                .Index(t => t.DaragaId)
                .Index(t => t.RotbaId);

            CreateTable(
                    "dbo.Qarars",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        SoldierId = c.Int(nullable: false),
                        CaptinId = c.Int(nullable: false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recorders", t => t.CaptinId, cascadeDelete: false)
                .ForeignKey("dbo.Recorders", t => t.SoldierId, cascadeDelete: false)
                .Index(t => t.SoldierId)
                .Index(t => t.CaptinId);
                
            
            CreateTable(
                "dbo.Rotbas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recorders", "RotbaId", "dbo.Rotbas");
            DropForeignKey("dbo.Qarars", "SoldierId", "dbo.Recorders");
            DropForeignKey("dbo.Qarars", "CaptinId", "dbo.Recorders");
            DropForeignKey("dbo.Recorders", "DaragaId", "dbo.Daragas");
            DropIndex("dbo.Qarars", new[] { "Recorder_Id" });
            DropIndex("dbo.Qarars", new[] { "CaptinId" });
            DropIndex("dbo.Qarars", new[] { "SoldierId" });
            DropIndex("dbo.Recorders", new[] { "RotbaId" });
            DropIndex("dbo.Recorders", new[] { "DaragaId" });
            DropTable("dbo.Rotbas");
            DropTable("dbo.Qarars");
            DropTable("dbo.Recorders");
            DropTable("dbo.Daragas");
        }
    }
}
