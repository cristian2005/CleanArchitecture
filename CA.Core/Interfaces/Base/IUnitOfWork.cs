using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Core.Interfaces.Base
{
    public interface IUnitOfWork: IDisposable
    {
        Task<int> CompleteAsync();

        /*Aqui las interfaces que se usaran en el repositorio generico*/
        public IClienteRepository Cliente { get; }
    }
}
