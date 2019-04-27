using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionDuProduction.BL;
using GestionDuProduction.BL.Repositories;
using GestionDuProduction.DAL.Repositories;

namespace GestionDuProduction.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VegaContext _context;

        public UnitOfWork(VegaContext context)
        {
            _context = context;
            //Clients = new ClientRepository(_context);
            Utilisateur = new UtilisateurRepository(context);

        }

        //public IClientRepository Clients { get; private set; }
        public IUtilisateurRepository Utilisateur { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
