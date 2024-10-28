using CA.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Infrastructure.Persistence.DbContexts
{
    public class AppDbContext : DbContext
    {
        #region Atributos
        #endregion

        #region Constructor
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
           
        }
        #endregion

        #region DbSet
        public virtual DbSet<Cliente> Clientes { get; set; }

        #endregion
    }
}
