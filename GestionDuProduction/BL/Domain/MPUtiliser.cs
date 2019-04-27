using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDuProduction.BL.Domain
{
    public class MPUtiliser
    {
        public int ID { get; set; }

        public int OFID { get; set; }

        public int MPID { get; set; }

        public OrdreFabrication OrdreFabrication { get; set; }

        public MatierePrimaire MatierePrimaire { get; set; }
    }
}
