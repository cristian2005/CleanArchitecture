using AutoMapper;
using CA.Core.Entities;
using CA.Core.Interfaces.Base;
using CA.Infrastructure.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Infrastructure.Application.Features.Clientes.Queries.GetCliente
{
    public class GetClienteQueryHandler : IRequestHandler<GetClienteQuery, IEnumerable<ClienteDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetClienteQueryHandler(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<IEnumerable<ClienteDTO>> Handle(GetClienteQuery request, CancellationToken cancellationToken)
        {
           var result = await this._unitOfWork.Cliente.GetAllAsync();
            return _mapper.Map<IEnumerable<ClienteDTO>>(result);
        }
    }
}
