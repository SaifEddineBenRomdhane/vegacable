namespace GestionDuProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSuiviAvancementOFTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SuiviAvancementOFs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OFID = c.Int(nullable: false),
                        SeqID = c.Int(nullable: false),
                        avencement = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OrdreFabrications", t => t.OFID, cascadeDelete: true)
                .ForeignKey("dbo.Sequences", t => t.SeqID, cascadeDelete: true)
                .Index(t => t.OFID)
                .Index(t => t.SeqID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SuiviAvancementOFs", "SeqID", "dbo.Sequences");
            DropForeignKey("dbo.SuiviAvancementOFs", "OFID", "dbo.OrdreFabrications");
            DropIndex("dbo.SuiviAvancementOFs", new[] { "SeqID" });
            DropIndex("dbo.SuiviAvancementOFs", new[] { "OFID" });
            DropTable("dbo.SuiviAvancementOFs");
        }
    }
}
