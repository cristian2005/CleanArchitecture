using CA.Core.Interfaces.Base;
using CA.Infrastructure.Persistence.DbContexts;
using CA.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Infrastructure.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Atributos

        private readonly AppDbContext? _context;
        #endregion

        #region Constructor
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Cliente = new ClienteRepository(context);
        }

        #endregion

        /*Aqui los repositorios genericos por entidades*/
        public IClienteRepository Cliente { get; private set; }

        #region Metodos Implementados
        public async Task<int> CompleteAsync()
            => await _context!.SaveChangesAsync();
        public void Dispose()
        {
            _context!.Dispose();
        }
        #endregion
    }
}
