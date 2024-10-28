using CA.Core.Entities;
using CA.Infrastructure.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Infrastructure.Application.Features.Clientes.Queries.GetClienteById
{
    public record GetClienteByIdQuery(int id): IRequest<ClienteDTO>
    {
    }
}
