using CA.Core.Entities;
using CA.Core.Interfaces.Base;
using CA.Infrastructure.Application.DTOs;
using CA.Infrastructure.Application.Features.Clientes.Commands.CreateCliente;
using CA.Infrastructure.Application.Features.Clientes.Commands.DeleteCliente;
using CA.Infrastructure.Application.Features.Clientes.Commands.UpdateCliente;
using CA.Infrastructure.Application.Features.Clientes.Queries.GetCliente;
using CA.Infrastructure.Application.Features.Clientes.Queries.GetClienteById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Prueba.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ISender _sender;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
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
            return Ok(1);
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
