using CA.Core.Wrappers;
using CA.Infrastructure.Application.DTOs;
using CA.Infrastructure.Application.Features.Clientes.Commands.CreateCliente;
using CA.Infrastructure.Application.Features.Clientes.Commands.DeleteCliente;
using CA.Infrastructure.Application.Features.Clientes.Commands.UpdateCliente;
using CA.Infrastructure.Application.Features.Clientes.Queries.GetCliente;
using CA.Infrastructure.Application.Features.Clientes.Queries.GetClienteById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly ISender _sender;

        public ClienteController(ILogger<ClienteController> logger,
            ISender sender)
        {
            _logger = logger;
            this._sender = sender;
        }

        [HttpGet]
        public async Task<object> Get()
        {
            return await _sender.Send(new GetClienteQuery());
        }
        [HttpGet("{id}")]
        public async Task<ClienteDTO> GetById(int id)
        {
            return await _sender.Send(new GetClienteByIdQuery(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateClienteCommand command)
        {
            var result = await _sender.Send(command);
            if(result == 0)
            {
                return BadRequest(ApiResponse<ClienteDTO>.Failure("Cliente no encontrado"));
            }
            var client = await _sender.Send(new GetClienteByIdQuery(result));
            return Ok(ApiResponse<ClienteDTO>.Success(client, "Cliente creado con exito"));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateClienteCommand command)
        {
            if (id != command.id)
                return BadRequest(); // HTTP 400 Bad Request

            await _sender.Send(command);
            return NoContent(); // HTTP 204 No Content
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _sender.Send(new DeleteClienteCommand(id));
            return NoContent(); // HTTP 204 No Content
        }
    }
}
