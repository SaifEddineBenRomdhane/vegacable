using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDuProduction.BL.Domain
{
    public class Nomenclature
    {
        public int ID { get; set; }

        public string Designation { get; set; }

        public string NormeRef { get; set; }

        public int ColorId { get; set; }

        public string Conditionnement { get; set; }

        public Couleur Couleur { get; set; }

        public ICollection<NomenclatureSequences> NomenclatureSequences { get; set; }

        public ICollection<OrdreFabrication> OrdreFabrications { get; set; }
    }
}
