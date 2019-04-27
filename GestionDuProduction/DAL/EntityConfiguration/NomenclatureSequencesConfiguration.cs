using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionDuProduction.BL.Domain;

namespace GestionDuProduction.DAL.EntityConfiguration
{
    class NomenclatureSequencesConfiguration : EntityTypeConfiguration<NomenclatureSequences>
    {
        public NomenclatureSequencesConfiguration()
        {
            HasKey(c => c.ID);

            HasRequired(c => c.Composant)
                .WithMany(c => c.NomenclatureSequenceses)
                .HasForeignKey(c => c.ComposantId);

            HasRequired(c => c.Sequence)
                .WithMany(c => c.NomenclatureSequenceses)
                .HasForeignKey(c => c.SequenceId);

            HasRequired(c => c.Nomenclature)
                .WithMany(c => c.NomenclatureSequences)
                .HasForeignKey(c => c.NomenclatureID);
        }
    }
}
