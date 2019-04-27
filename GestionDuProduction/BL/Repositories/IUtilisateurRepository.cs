using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionDuProduction.BL.Domain;

namespace GestionDuProduction.BL.Repositories
{
    public interface IUtilisateurRepository : IRepository<Utilisateur>
    {
        IEnumerable<Utilisateur> AllUtilisateurs();
    }
}
