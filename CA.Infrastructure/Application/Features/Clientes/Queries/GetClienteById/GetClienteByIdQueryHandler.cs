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

namespace CA.Infrastructure.Application.Features.Clientes.Queries.GetClienteById
{
    public class GetClienteByIdQueryHandler :
        IRequestHandler<GetClienteByIdQuery, ClienteDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetClienteByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<ClienteDTO> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
        {
           var result = await this._unitOfWork.Cliente.GetByIdAsyn(request.id);
            return _mapper.Map<ClienteDTO>(result);
        }
    }
}
