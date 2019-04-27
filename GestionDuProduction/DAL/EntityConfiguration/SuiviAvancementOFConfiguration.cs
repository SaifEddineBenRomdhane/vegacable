using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionDuProduction.BL.Domain;

namespace GestionDuProduction.DAL.EntityConfiguration
{
    class SuiviAvancementOFConfiguration : EntityTypeConfiguration<SuiviAvancementOF>
    {
        public SuiviAvancementOFConfiguration()
        {
            HasKey(c => c.ID);

            HasRequired(c => c.OrdreFabrication)
                .WithMany(c => c.SuiviAvancement)
                .HasForeignKey(c => c.OFID);

            HasRequired(c => c.Sequence)
                .WithMany(c => c.SuiviAvancement)
                .HasForeignKey(c => c.SeqID);
        }
    }
}
