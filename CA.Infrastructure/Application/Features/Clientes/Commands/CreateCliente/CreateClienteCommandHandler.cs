using AutoMapper;
using CA.Core.Entities;
using CA.Core.Interfaces.Base;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Infrastructure.Application.Features.Clientes.Commands.CreateCliente
{
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, int>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<CreateClienteCommandHandler> logger;

        public CreateClienteCommandHandler(IUnitOfWork unitOfWork,
            IMapper mapper, ILogger<CreateClienteCommandHandler> logger)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }
        public async Task<int> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cliente = mapper.Map<Cliente>(request);
                await unitOfWork.Cliente.AddAsync(cliente);
                await unitOfWork.CompleteAsync();
                return cliente.Id;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return 0;
            }
        }
    }
}
