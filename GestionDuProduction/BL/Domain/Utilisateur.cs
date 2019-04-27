using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDuProduction.BL.Domain
{
    public class Utilisateur
    {
        public int ID { get; set; }

        public string Nom { get;set; }

        public string NomUtilisateur { get; set; }

        public int Mobile { get; set; }

        public string MotdePass { get; set; }

        public int? GroupId { get; set; }

        public Group Group { get; set; }

        public ICollection<MatierePrimaire> MatePrimaires { get; set; }
    }
}
