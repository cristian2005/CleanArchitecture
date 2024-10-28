using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Infrastructure.Application.DTOs
{
    public record ClienteDTO( int? Id, string? Nombre, string? Apellidos )
    {
    }
}
