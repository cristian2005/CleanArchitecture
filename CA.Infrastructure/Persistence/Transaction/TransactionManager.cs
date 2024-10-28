using CA.Core.Interfaces.Base;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Infrastructure.Persistence.Transaction
{
    public class TransactionManager : ITransaction
    {
        #region Atributos
        private readonly DbContext? _context;
        private IDbContextTransaction? _transaction;
        #endregion

        #region Constructor
        public TransactionManager(DbContext context)
        {
            _context = context;
        }
        #endregion

        #region Metodos Implementados
        public async Task CreateTransactionAsync()
        {
            _transaction = await _context!.Database.BeginTransactionAsync();
        }
        public async Task CreateTransactionAsync(CancellationToken cancellationToken = default)
        {
            _transaction = await _context!.Database.BeginTransactionAsync(cancellationToken);
        }
        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await _context!.SaveChangesAsync(cancellationToken);
                await _transaction!.CommitAsync(cancellationToken);
            }
            catch
            {
                await RollbackAsync(cancellationToken);
                throw;
            }
            finally
            {
                await _transaction!.DisposeAsync();
            }
        }
        public async Task RollbackAsync()
        {
            await _transaction!.RollbackAsync();
            await _transaction.DisposeAsync();
        }
        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            await _transaction!.RollbackAsync(cancellationToken);
            await _transaction.DisposeAsync();
        }
        #endregion
    }
}
