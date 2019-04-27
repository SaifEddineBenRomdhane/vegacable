using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using GestionDuProduction.BL.Domain;
using GestionDuProduction.DAL.EntityConfiguration;
using System.Data;

namespace GestionDuProduction.DAL
{
    public class VegaContext : DbContext
    {
        public static string stri = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        //public static string con = @"Data Source = .; Initial Catalog=VegaCable; Integrated Security=True";
        public static string con = $@"{stri}; Initial Catalog=VegaCableProd; User Id = sa; Password = M@ut%^k/12#3456";

        public VegaContext()
            : base(con)
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Composant> Composants { get; set; }
        public virtual DbSet<Couleur> Couleurs { get; set; }
        public virtual DbSet<MatierePrimaire> MatierePrimaires { get; set; }
        public virtual DbSet<BL.Domain.Nomenclature> Nomenclatures { get; set; }
        public virtual DbSet<NomenclatureSequences> NomenclatureSequenceses { get; set; }
        public virtual DbSet<Sequence> Sequences { get; set; }
        public virtual DbSet<OrdreFabrication> OrdreFabrications { get; set; }
        public virtual DbSet<MPUtiliser> MPUtilisers { get; set; }
        public virtual DbSet<SuiviAvancementOF> SuiviAvancement { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UtilisateurConfiguration()/*.Ignore(c => c.Group)*/);
            modelBuilder.Configurations.Add(new GroupConfiguration());
            modelBuilder.Configurations.Add(new MatierePrimaireConfiguration());
            modelBuilder.Configurations.Add(new NomenclatureSequencesConfiguration());
            modelBuilder.Configurations.Add(new NomenclatureConfiguration());
            modelBuilder.Configurations.Add(new OrdreFabricationConfiguration());
            modelBuilder.Configurations.Add(new SuiviAvancementOFConfiguration());
        }
    }
}
