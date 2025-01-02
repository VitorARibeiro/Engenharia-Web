using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NOR_2023_01_24.Models;

public class VeiculosController : Controller
{
    private readonly MyDbContext _context;

    public VeiculosController(MyDbContext context)
    {
        _context = context;
    }

    // GET: Veiculos/Adicionar/{id}
    public async Task<IActionResult> Adicionar(int id)
    {
        var proprietario = await _context.Proprietarios.FindAsync(id);
        if (proprietario == null)
        {
            return NotFound();
        }

        ViewBag.ProprietarioId = id;
        ViewBag.ProprietarioNome = proprietario.Nome;
        return View();
    }

    // POST: Veiculos/Adicionar
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Adicionar([Bind("Matricula,Marca,Modelo,ProprietarioId")] Veiculo veiculo)
    {
        if (ModelState.IsValid)
        {
            var matriculaExistente = await _context.Veiculos
                .AnyAsync(v => v.Matricula == veiculo.Matricula);

            if (matriculaExistente)
            {
                ModelState.AddModelError("Matricula", "A matrícula já existe.");
                var proprietario = await _context.Proprietarios.FindAsync(veiculo.ProprietarioId);
                ViewBag.ProprietarioNome = proprietario?.Nome;
                return View(veiculo);
            }

            _context.Add(veiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Proprietarios", new { id = veiculo.ProprietarioId });
        }

        var proprietarioAtual = await _context.Proprietarios.FindAsync(veiculo.ProprietarioId);
        ViewBag.ProprietarioNome = proprietarioAtual?.Nome;
        return View(veiculo);
    }
}
