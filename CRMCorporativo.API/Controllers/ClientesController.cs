using CRMCorporativo.Application.DTOs;
using CRMCorporativo.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRMCorporativo.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _clienteService;
    public ClientesController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get()
    {
        var clientes = await _clienteService.GetClientes();
        if (clientes == null)
        {
            return NotFound("Clientes not found");
        }
        return Ok(clientes);
    }

    [HttpGet("{id}", Name = "GetCliente")]
    public async Task<ActionResult<ClienteDTO>> Get(int id)
    {
        var produto = await _clienteService.GetById(id);
        if (produto == null)
        {
            return NotFound("Product not found");
        }
        return Ok(produto);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ClienteDTO clienteDto)
    {
        if (clienteDto == null)
            return BadRequest("Data Invalid");

        await _clienteService.Add(clienteDto);

        return new CreatedAtRouteResult("GetCliente",
            new { id = clienteDto.Id }, clienteDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] ClienteDTO clienteDto)
    {
        if (id != clienteDto.Id)
        {
            return BadRequest("Data invalid");
        }

        if (clienteDto == null)
            return BadRequest("Data invalid");

        await _clienteService.Update(clienteDto);

        return Ok(clienteDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ClienteDTO>> Delete(int id)
    {
        var clienteDto = await _clienteService.GetById(id);

        if (clienteDto == null)
        {
            return NotFound("Cliente not found");
        }

        await _clienteService.Remove(id);

        return Ok(clienteDto);
    }
}
