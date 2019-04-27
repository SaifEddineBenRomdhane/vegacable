using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDuProduction.BL.Domain
{
    public class OrdreFabrication
    {
        public int ID { get; set; }

        public int NomenclatureID { get; set; }

        public float Lonngeur { get; set; }

        public Etat Status { get; set; }

        public DateTime DateLancer { get; set; }

        public DateTime DateCloture { get; set; }

        public Nomenclature Nomenclature { get; set; }

        public ICollection<MPUtiliser> MpUtilisers { get; set; }

        public ICollection<SuiviAvancementOF> SuiviAvancement { get; set; }

        public enum Etat
        {
            Lances = 1,
            Cloture =2
        }
    }
}
