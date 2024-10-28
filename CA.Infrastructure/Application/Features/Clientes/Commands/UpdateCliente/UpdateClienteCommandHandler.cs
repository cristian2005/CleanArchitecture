using AutoMapper;
using CA.Core.Entities;
using CA.Core.Interfaces.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Infrastructure.Application.Features.Clientes.Commands.UpdateCliente
{
    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, Cliente>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateClienteCommandHandler(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<Cliente> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var clienteFound = await this._unitOfWork.Cliente.GetByIdAsyn(request.id);
            if(clienteFound == null) 
                throw new KeyNotFoundException("Cliente no encontrado");

            var cliente = _mapper.Map(request,clienteFound);

            this._unitOfWork.Cliente.Update(cliente);
            await this._unitOfWork.CompleteAsync();

            return cliente;
        }
    }
}
