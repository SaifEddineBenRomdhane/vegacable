using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDuProduction.BL.Domain
{
    public class MatierePrimaire
    {
        public int ID { get; set; }

        public int ComposantID { get; set; }

        public string Matricule { get; set; }

        public float Mass { get; set; }

        public string Lot { get; set; }

        public DateTime ImpDate { get; set; }

        public DateTime UpDate { get; set; }

        public int useId { get; set; }

        public status Etat { get; set; }

        public float RestMass { get; set; }

        public Composant Composant { get; set; }

        public Utilisateur Utilisateur { get; set; }

        public ICollection<MPUtiliser> MpUtilisers { get; set; }

        public enum status
        {
             Dispo = 0,
            Resrv = 1 ,
            Epuise =2,
        }
    }
}
