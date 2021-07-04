using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciaProjeto.Data;
using GerenciaProjeto.Models;
using GerenciaProjeto.Services;

namespace GerenciaProjeto.Controllers
{
    public class SistemasController : Controller
    {
        private readonly GerenciaProjetoContext _context;
        private readonly SistemaService _sistemaService;

        public SistemasController(GerenciaProjetoContext context, SistemaService sistemaService)
        {
            _context = context;
            _sistemaService = sistemaService;
        }

        // GET: Sistemas
        public async Task<IActionResult> Inicio(int? numeroPagina, string pesquisa)
        {
            int _numeroPagina = numeroPagina ?? 1;
            ViewData["pesquisa"] = pesquisa;

            return View(await PaginatedList<Sistema>.CreateAsync(_sistemaService.ListaSistemas(pesquisa), _numeroPagina));
        }

        // GET: Sistemas/Visualizar/5
        public async Task<IActionResult> Visualizar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sistema = await _context.Sistema
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sistema == null)
            {
                return NotFound();
            }

            return View(sistema);
        }

        // GET: Sistemas/Criar
        public IActionResult Criar()
        {
            return View();
        }

        // POST: Sistemas/Criar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("Id,Nome")] Sistema sistema)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sistema);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Inicio));
            }
            return View(sistema);
        }

        // GET: Sistemas/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sistema = await _context.Sistema.FindAsync(id);
            if (sistema == null)
            {
                return NotFound();
            }
            return View(sistema);
        }

        // POST: Sistemas/Editar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,Nome")] Sistema sistema)
        {
            if (id != sistema.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sistema);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SistemaExists(sistema.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Inicio));
            }
            return View(sistema);
        }

        // GET: Sistemas/Deletar/5
        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sistema = await _context.Sistema
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sistema == null)
            {
                return NotFound();
            }

            return View(sistema);
        }

        // POST: Sistemas/Deletar/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DelecaoConfirmada(int id)
        {
            var sistema = await _context.Sistema.FindAsync(id);
            _context.Sistema.Remove(sistema);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Inicio));
        }

        private bool SistemaExists(int id)
        {
            return _context.Sistema.Any(e => e.Id == id);
        }
    }
}
