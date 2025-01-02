using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NOR_2022_02_08.Models;
using NOR_2022_02_08.ViewModels;
using System.Diagnostics;

namespace NOR_2022_02_08.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MeuDbContext _context;

        public HomeController(ILogger<HomeController> logger, MeuDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Home/Index
        public async Task<IActionResult> Index()
        {
            var empresas = await _context.Empresas
                .Include(e => e.Pais)
                .OrderBy(e => e.Pais.Nome)
                .ToListAsync();
            return View(empresas);
        }

        // GET: Home/Registo
        public async Task<IActionResult> Registo()
        {
            ViewData["PaisId"] = new SelectList(await _context.Paises.ToListAsync(), "Id", "Nome");
            return View();
        }

        // POST: Home/Registo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registo(EmpresaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var pais = await _context.Paises.FirstOrDefaultAsync(p => p.Id == model.PaisId);
                if (pais == null)
                {
                    ModelState.AddModelError("PaisId", "País não encontrado.");
                    ViewData["PaisId"] = new SelectList(await _context.Paises.ToListAsync(), "Id", "Nome", model.PaisId);
                    return View(model);
                }

                var empresa = new Empresa
                {
                    Nome = model.Nome,
                    PaisId = model.PaisId,
                    Pais = pais
                };

                if (model.Logotipo != null && model.Logotipo.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Logos", model.Logotipo.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Logotipo.CopyToAsync(stream);
                    }
                    empresa.Logotipo = model.Logotipo.FileName;
                }

                _context.Add(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }
            ViewData["PaisId"] = new SelectList(await _context.Paises.ToListAsync(), "Id", "Nome", model.PaisId);
            return View(model);
        }

        // GET: Empresas/{abreviaturaPais}
        [HttpGet("/Empresas/{abreviaturaPais}")]
        public async Task<IActionResult> EmpresasPorPais(string abreviaturaPais)
        {
            if (string.IsNullOrEmpty(abreviaturaPais))
            {
                return BadRequest("Abreviatura do país é obrigatória.");
            }

            var pais = await _context.Paises
                .Include(p => p.Empresas)
                .FirstOrDefaultAsync(p => p.Abreviatura == abreviaturaPais);

            if (pais == null)
            {
                return NotFound("País não encontrado.");
            }

            var empresas = pais.Empresas.OrderBy(e => e.Nome).ToList();
            return View("Index", empresas);
        }

        // POST: Home/Apagar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apagar(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa != null)
            {
                // Apagar o logotipo do sistema de arquivos, se existir
                if (!string.IsNullOrEmpty(empresa.Logotipo))
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Logos", empresa.Logotipo);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }

                _context.Empresas.Remove(empresa);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
