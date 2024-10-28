using CA.Core.Interfaces.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Infrastructure.Application.Features.Clientes.Commands.DeleteCliente
{
    public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteClienteCommandHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var clienteFound = await this._unitOfWork.Cliente.GetByIdAsyn(request.id);
            this._unitOfWork.Cliente.Remove(clienteFound);
            await this._unitOfWork.CompleteAsync();
            return 1;
        }
    }
}
