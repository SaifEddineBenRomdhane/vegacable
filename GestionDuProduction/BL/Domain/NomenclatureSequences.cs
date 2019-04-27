using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDuProduction.BL.Domain
{
    public class NomenclatureSequences
    {
        public int ID { get; set; }

        public int NomenclatureID { get; set; }

        public int SequenceId { get; set; }

        public int ComposantId { get; set; }

        public float Mass { get; set; }

        public Sequence Sequence { get; set; }

        public Composant Composant { get; set; }

        public Nomenclature Nomenclature { get; set; }
    }
}
