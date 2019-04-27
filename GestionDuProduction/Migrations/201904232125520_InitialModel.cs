namespace GestionDuProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Composants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MatierePrimaires",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ComposantID = c.Int(nullable: false),
                        Matricule = c.String(nullable: false, maxLength: 4000),
                        Mass = c.Single(nullable: false),
                        Lot = c.String(),
                        ImpDate = c.DateTime(nullable: false),
                        UpDate = c.DateTime(nullable: false),
                        useId = c.Int(nullable: false),
                        Etat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Composants", t => t.ComposantID, cascadeDelete: true)
                .ForeignKey("dbo.Utilisateurs", t => t.useId, cascadeDelete: true)
                .Index(t => t.ComposantID)
                .Index(t => t.useId);
            
            CreateTable(
                "dbo.MPUtilisers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OFID = c.Int(nullable: false),
                        MPID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OrdreFabrications", t => t.OFID, cascadeDelete: true)
                .ForeignKey("dbo.MatierePrimaires", t => t.MPID, cascadeDelete: true)
                .Index(t => t.OFID)
                .Index(t => t.MPID);
            
            CreateTable(
                "dbo.OrdreFabrications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NomenclatureID = c.Int(nullable: false),
                        Lonngeur = c.Single(nullable: false),
                        Status = c.Int(nullable: false),
                        DateLancer = c.DateTime(nullable: false),
                        DateCloture = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Nomenclatures", t => t.NomenclatureID, cascadeDelete: true)
                .Index(t => t.NomenclatureID);
            
            CreateTable(
                "dbo.Nomenclatures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Designation = c.String(nullable: false, maxLength: 4000),
                        NormeRef = c.String(nullable: false, maxLength: 4000),
                        ColorId = c.Int(nullable: false),
                        Conditionnement = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Couleurs", t => t.ColorId, cascadeDelete: true)
                .Index(t => t.ColorId);
            
            CreateTable(
                "dbo.Couleurs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.NomenclatureSequences",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NomenclatureID = c.Int(nullable: false),
                        SequenceId = c.Int(nullable: false),
                        ComposantId = c.Int(nullable: false),
                        Mass = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Composants", t => t.ComposantId, cascadeDelete: true)
                .ForeignKey("dbo.Nomenclatures", t => t.NomenclatureID, cascadeDelete: true)
                .ForeignKey("dbo.Sequences", t => t.SequenceId, cascadeDelete: true)
                .Index(t => t.NomenclatureID)
                .Index(t => t.SequenceId)
                .Index(t => t.ComposantId);
            
            CreateTable(
                "dbo.Sequences",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Utilisateurs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 4000),
                        NomUtilisateur = c.String(nullable: false, maxLength: 4000),
                        Mobile = c.Int(nullable: false),
                        MotdePass = c.String(nullable: false, maxLength: 4000),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NomGroup = c.String(nullable: false, maxLength: 4000),
                        NomCla = c.Boolean(nullable: false),
                        OrderF = c.Boolean(nullable: false),
                        UseG = c.Boolean(nullable: false),
                        MatierP = c.Boolean(nullable: false),
                        User = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MatierePrimaires", "useId", "dbo.Utilisateurs");
            DropForeignKey("dbo.Utilisateurs", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.MPUtilisers", "MPID", "dbo.MatierePrimaires");
            DropForeignKey("dbo.OrdreFabrications", "NomenclatureID", "dbo.Nomenclatures");
            DropForeignKey("dbo.NomenclatureSequences", "SequenceId", "dbo.Sequences");
            DropForeignKey("dbo.NomenclatureSequences", "NomenclatureID", "dbo.Nomenclatures");
            DropForeignKey("dbo.NomenclatureSequences", "ComposantId", "dbo.Composants");
            DropForeignKey("dbo.Nomenclatures", "ColorId", "dbo.Couleurs");
            DropForeignKey("dbo.MPUtilisers", "OFID", "dbo.OrdreFabrications");
            DropForeignKey("dbo.MatierePrimaires", "ComposantID", "dbo.Composants");
            DropIndex("dbo.Utilisateurs", new[] { "GroupId" });
            DropIndex("dbo.NomenclatureSequences", new[] { "ComposantId" });
            DropIndex("dbo.NomenclatureSequences", new[] { "SequenceId" });
            DropIndex("dbo.NomenclatureSequences", new[] { "NomenclatureID" });
            DropIndex("dbo.Nomenclatures", new[] { "ColorId" });
            DropIndex("dbo.OrdreFabrications", new[] { "NomenclatureID" });
            DropIndex("dbo.MPUtilisers", new[] { "MPID" });
            DropIndex("dbo.MPUtilisers", new[] { "OFID" });
            DropIndex("dbo.MatierePrimaires", new[] { "useId" });
            DropIndex("dbo.MatierePrimaires", new[] { "ComposantID" });
            DropTable("dbo.Groups");
            DropTable("dbo.Utilisateurs");
            DropTable("dbo.Sequences");
            DropTable("dbo.NomenclatureSequences");
            DropTable("dbo.Couleurs");
            DropTable("dbo.Nomenclatures");
            DropTable("dbo.OrdreFabrications");
            DropTable("dbo.MPUtilisers");
            DropTable("dbo.MatierePrimaires");
            DropTable("dbo.Composants");
        }
    }
}
