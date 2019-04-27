using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDuProduction.BL.Domain
{
    public class Composant
    {
        public int ID { get; set; }

        public string Designation { get; set; }

        public ICollection<MatierePrimaire> MatierePrimaires { get; set; }

        public ICollection<NomenclatureSequences> NomenclatureSequenceses { get; set; }
    }
}
