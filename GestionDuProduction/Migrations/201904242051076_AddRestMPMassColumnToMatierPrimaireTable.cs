namespace GestionDuProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRestMPMassColumnToMatierPrimaireTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MatierePrimaires", "RestMass", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MatierePrimaires", "RestMass");
        }
    }
}
