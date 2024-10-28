using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CA.Core.Entities;
using CA.Infrastructure.Application.DTOs;
using CA.Infrastructure.Application.Features.Clientes.Commands.CreateCliente;
using CA.Infrastructure.Application.Features.Clientes.Commands.UpdateCliente;
namespace CA.Infrastructure.Application.Mappings
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cliente, CreateClienteCommand>().ReverseMap();
            CreateMap<Cliente, UpdateClienteCommand>().ReverseMap();
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
        }
    }
}
