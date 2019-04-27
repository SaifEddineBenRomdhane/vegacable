using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDuProduction.BL.Domain
{
    public class Group
    {
        public int ID { get; set; }

        public string NomGroup { get; set; }

        public bool NomCla { get; set; }

        public bool OrderF { get; set; }

        public bool UseG { get; set; }

        public bool MatierP { get; set; }

        public bool User { get; set; }

        public virtual ICollection<Utilisateur> Utilisateurs { get; set; }
    }
}
