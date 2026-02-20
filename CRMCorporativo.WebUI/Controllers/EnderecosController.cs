using CRMCorporativo.Application.DTOs;
using CRMCorporativo.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRMCorporativo.WebUI.Controllers;

[Authorize]
public class EnderecosController : Controller
{
    private readonly IEnderecoService _enderecoService;
    public EnderecosController(IEnderecoService enderecoService)
    {
        _enderecoService = enderecoService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var enderecos = await _enderecoService.GetEnderecos();
        return View(enderecos);
    }

    [HttpGet()]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(EnderecoDTO enderecos)
    {
        if (ModelState.IsValid)
        {
            await _enderecoService.Add(enderecos);
            return RedirectToAction(nameof(Index));
        }
        return View(enderecos);
    }

    [HttpGet()]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var enderecoDto = await _enderecoService.GetById(id);
        if (enderecoDto == null) return NotFound();
        return View(enderecoDto);
    }

    [HttpPost()]
    public async Task<IActionResult> Edit(EnderecoDTO enderecoDto)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _enderecoService.Update(enderecoDto);
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(enderecoDto);
    }

    [HttpGet()]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var enderecoDto = await _enderecoService.GetById(id);

        if (enderecoDto == null) return NotFound();

        return View(enderecoDto);
    }

    [HttpPost(), ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _enderecoService.Remove(id);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
            return NotFound();

        var enderecoDto = await _enderecoService.GetById(id);

        if (enderecoDto == null)
            return NotFound();

        return View(enderecoDto);
    }
}
