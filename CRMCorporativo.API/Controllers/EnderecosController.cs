using CRMCorporativo.Application.DTOs;
using CRMCorporativo.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRMCorporativo.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class EnderecosController : ControllerBase
{
    private readonly IEnderecoService _enderecoService;
    public EnderecosController(IEnderecoService enderecoService)
    {
        _enderecoService = enderecoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EnderecoDTO>>> Get()
    {
        var endereco = await _enderecoService.GetEnderecos();
        if (endereco == null)
        {
            return NotFound("Enderecos not found");
        }
        return Ok(endereco);
    }

    /// <summary>
    /// Localiza uma categoria específica pelo Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [HttpGet("{id:int}", Name = "GetEndereco")]
    public async Task<ActionResult<EnderecoDTO>> Get(int id)
    {
        var endereco = await _enderecoService.GetById(id);
        if (endereco == null)
        {
            return NotFound("Endereco not found");
        }
        return Ok(endereco);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] EnderecoDTO enderecoDto)
    {
        if (enderecoDto == null)
            return BadRequest("Invalid Data");

        await _enderecoService.Add(enderecoDto);

        return new CreatedAtRouteResult("GetEndereco", new { id = enderecoDto.Id },
            enderecoDto);
    }

    [HttpPut]
    public async Task<ActionResult> Put(int id, [FromBody] EnderecoDTO enderecoDto)
    {
        if (id != enderecoDto.Id)
            return BadRequest();

        if (enderecoDto == null)
            return BadRequest();

        await _enderecoService.Update(enderecoDto);

        return Ok(enderecoDto);
    }

    /// <summary>
    /// Deleta uma categoria específica
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<EnderecoDTO>> Delete(int id)
    {
        var endereco = await _enderecoService.GetById(id);
        if (endereco == null)
        {
            return NotFound("Endereco not found");
        }

        await _enderecoService.Remove(id);

        return Ok(endereco);

    }
}
