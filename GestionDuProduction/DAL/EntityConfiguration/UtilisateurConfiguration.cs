using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionDuProduction.BL.Domain;

namespace GestionDuProduction.DAL.EntityConfiguration
{
    public class UtilisateurConfiguration : EntityTypeConfiguration<Utilisateur>
    {
        public UtilisateurConfiguration()
        {
            HasKey(c => c.ID);

            Property(c => c.Nom)
                .IsRequired()
                .HasColumnType("nvarchar");

            Property(c => c.NomUtilisateur)
                .IsRequired()
                .HasColumnType("nvarchar");

            Property(c => c.MotdePass)
                .IsRequired()
                .HasColumnType("nvarchar");

            HasRequired(c => c.Group)
                .WithMany(c => c.Utilisateurs)
                .HasForeignKey(c => c.GroupId);

            HasMany(c => c.MatePrimaires)
                .WithRequired(c => c.Utilisateur)
                .HasForeignKey(c => c.useId);

        }
    }
}
