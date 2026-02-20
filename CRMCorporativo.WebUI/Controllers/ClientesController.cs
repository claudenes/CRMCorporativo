using CRMCorporativo.Application.DTOs;
using CRMCorporativo.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRMCorporativo.WebUI.Controllers;

public class ClientesController : Controller
{
    private readonly IClienteService _clienteService;
    private readonly IEnderecoService _enderecoService;
    private readonly IWebHostEnvironment _environment;

    public ClientesController(IClienteService clienteAppService,
        IEnderecoService enderecoService, IWebHostEnvironment environment)
    {
        _clienteService = clienteAppService;
        _enderecoService = enderecoService;
        _environment = environment;


    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var clientes = await _clienteService.GetClientes();
        return View(clientes);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.CategoryId =
        new SelectList(await _enderecoService.GetEnderecos(), "Id", "Logradouro");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ClienteDTO clienteDto)
    {
        if (ModelState.IsValid)
        {
            await _clienteService.Add(clienteDto);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            ViewBag.CategoryId =
                        new SelectList(await _enderecoService.GetEnderecos(), "Id", "Logradouro");
        }
        return View(clienteDto);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var clienteDto = await _clienteService.GetById(id);

        if (clienteDto == null) return NotFound();

        var enderecos = await _enderecoService.GetEnderecos();
        ViewBag.EnderecoId = new SelectList(enderecos, "Id", "Logradouro", clienteDto.EnderecoId);

        return View(clienteDto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ClienteDTO clienteDto)
    {
        if (ModelState.IsValid)
        {
            await _clienteService.Update(clienteDto);
            return RedirectToAction(nameof(Index));
        }
        return View(clienteDto);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var clienteDto = await _clienteService.GetById(id);

        if (clienteDto == null) return NotFound();

        return View(clienteDto);
    }

    [HttpPost(), ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _clienteService.Remove(id);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var clienteDto = await _clienteService.GetById(id);

        if (clienteDto == null) return NotFound();
        var wwwroot = _environment.WebRootPath;
       
     

        return View(clienteDto);
    }
}
