using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDuProduction.DAL.EntityConfiguration
{
    public class NomenclatureConfiguration : EntityTypeConfiguration<BL.Domain.Nomenclature>
    {
        public NomenclatureConfiguration()
        {
            HasKey(c => c.ID);

            Property(c => c.Conditionnement)
                .IsRequired()
                .HasColumnType("nvarchar");

            Property(c => c.Designation)
                .IsRequired()
                .HasColumnType("nvarchar");

            Property(c => c.NormeRef)
                .IsRequired()
                .HasColumnType("nvarchar");

            HasRequired(c => c.Couleur)
                .WithMany(c => c.Nomenclatures)
                .HasForeignKey(c => c.ColorId);
        }
    }
}
