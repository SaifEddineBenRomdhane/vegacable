using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionDuProduction.BL.Domain;

namespace GestionDuProduction.DAL.EntityConfiguration
{
    public class OrdreFabricationConfiguration : EntityTypeConfiguration<OrdreFabrication>
    {
        public OrdreFabricationConfiguration()
        {
            HasKey(c => c.ID);

            HasRequired(c => c.Nomenclature)
                .WithMany(c => c.OrdreFabrications)
                .HasForeignKey(c => c.NomenclatureID);

            HasMany(c => c.MpUtilisers)
                .WithRequired(c => c.OrdreFabrication)
                .HasForeignKey(c => c.OFID);

        }
    }
}
