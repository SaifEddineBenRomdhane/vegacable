using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDuProduction.BL.Domain
{
    public class Couleur
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<Nomenclature> Nomenclatures { get; set; }
    }
}
