using CA.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Infrastructure.Application.Features.Clientes.Commands.UpdateCliente
{
    public record UpdateClienteCommand(int id, string nombre, string apellidos) : IRequest<Cliente>
    {
    }
}
