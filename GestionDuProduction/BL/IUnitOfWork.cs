using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionDuProduction.BL.Repositories;

namespace GestionDuProduction.BL
{
    public interface IUnitOfWork : IDisposable
    {
        IUtilisateurRepository Utilisateur { get; }
        int Complete();
    }
}
