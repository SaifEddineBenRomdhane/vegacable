using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionDuProduction.PL;

namespace GestionDuProduction.BL.Domain
{
    public class SuiviAvancementOF
    {
        public int ID { get; set; }

        public int OFID { get; set; }

        public int SeqID { get; set; }

        public Avencement avencement { get; set; }

        public OrdreFabrication OrdreFabrication { get; set; }

        public Sequence Sequence { get; set; }

        public enum Avencement
        {
            Attent = 0,
            EnCours = 1,
            Finis = 2
        }

    }
}
