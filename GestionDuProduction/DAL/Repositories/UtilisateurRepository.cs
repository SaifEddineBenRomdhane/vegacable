using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionDuProduction.BL.Domain;
using GestionDuProduction.BL.Repositories;

namespace GestionDuProduction.DAL.Repositories
{
    public class UtilisateurRepository : Repository<Utilisateur>, IUtilisateurRepository
    {
        public UtilisateurRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Utilisateur> AllUtilisateurs()
        {
            var s = VegaContext.Utilisateurs.OrderBy(c => c.ID).ToList();
            return s;
        }

        public VegaContext VegaContext
        {
            get { return Context as VegaContext;}
        }

    }
}
