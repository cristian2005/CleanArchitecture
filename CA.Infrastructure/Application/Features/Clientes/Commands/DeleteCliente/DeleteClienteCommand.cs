using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Infrastructure.Application.Features.Clientes.Commands.DeleteCliente
{
    public record DeleteClienteCommand(int id): IRequest<int>
    {
    }
}
