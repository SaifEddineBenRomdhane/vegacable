using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionDuProduction.BL.Domain;

namespace GestionDuProduction.DAL.EntityConfiguration
{
    public class MatierePrimaireConfiguration : EntityTypeConfiguration<MatierePrimaire>
    {
        public MatierePrimaireConfiguration()
        {
            HasKey(c => c.ID);

            Property(c => c.Matricule)
                .IsRequired()
                .HasColumnType("nvarchar");

            HasRequired(c => c.Composant)
                .WithMany(c => c.MatierePrimaires)
                .HasForeignKey(c => c.ComposantID);

            HasMany(c => c.MpUtilisers)
                .WithRequired(c => c.MatierePrimaire)
                .HasForeignKey(c => c.MPID);
        }
    }
}
