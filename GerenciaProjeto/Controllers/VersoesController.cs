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
using GerenciaProjeto.Models.ViewModels;

namespace GerenciaProjeto.Controllers
{
    public class VersoesController : Controller
    {
        private readonly GerenciaProjetoContext _context;
        private readonly VersaoService _versaoService;

        public VersoesController(GerenciaProjetoContext context, VersaoService versaoService)
        {
            _context = context;
            _versaoService = versaoService;
        }

        // GET: Versoes
        public async Task<IActionResult> Inicio(int sistemaId, int? numeroPagina, string pesquisa)
        {
            int _numeroPagina = numeroPagina ?? 1;
            ViewData["pesquisa"] = pesquisa;
            var sistema = await _context.Sistema.FindAsync(sistemaId);
            ViewData["Title"] = $"Versões {sistema.Nome}";
            ViewData["sistemaId"] = sistemaId;

            var result = from a in _context.AtualizacaoCliente
                         select a;
            ViewData["AtualizacoesClientes"] = result;

            VersaoViewModel viewModel = new()
            {
                Versoes = await _versaoService.ListaVersoes(sistemaId, pesquisa).ToListAsync(),
                AtualizacoesClientes = await _context.AtualizacaoCliente.ToListAsync()
            };
            return View(viewModel);
        }

        // GET: Versoes/Visualizar/5
        public async Task<IActionResult> Visualizar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var versao = await _context.Versao
                .Include(v => v.Sistema)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (versao == null)
            {
                return NotFound();
            }

            return View(versao);
        }

        // GET: Versoes/Criar
        public IActionResult Criar(int sistemaId)
        {
            ViewData["SistemaId"] = new SelectList(_context.Sistema.Where(s => s.Id == sistemaId), "Id", "Nome");
            ViewData["Numero"] = _context.Versao.Where(v => v.SistemaId == sistemaId).OrderByDescending(v => v.Data).Select(v => v.Numero).FirstOrDefault();
            return View();
        }

        // POST: Versoes/Criar
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("Id,Numero,Data,Nota,SistemaId")] Versao versao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(versao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Inicio), new { sistemaId = versao.SistemaId });
            }
            ViewData["SistemaId"] = new SelectList(_context.Sistema, "Id", "Nome", versao.SistemaId);
            return View(versao);
        }

        // GET: Versoes/Editar/5
        public async Task<IActionResult> Editar(int? id, int sistemaId)
        {
            ViewData["idSistema"] = sistemaId;

            if (id == null)
            {
                return NotFound();
            }

            var versao = await _context.Versao.FindAsync(id);
            if (versao == null)
            {
                return NotFound();
            }
            ViewData["SistemaId"] = new SelectList(_context.Sistema.Where(s => s.Id == sistemaId), "Id", "Nome");
            return View(versao);
        }

        // POST: Versoes/Editar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,Numero,Data,Nota,SistemaId")] Versao versao)
        {
            if (id != versao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(versao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VersaoExists(versao.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Inicio), new { sistemaId = versao.SistemaId });
            }
            ViewData["SistemaId"] = new SelectList(_context.Sistema, "Id", "Id", versao.SistemaId);
            return View(versao);
        }

        // GET: Versoes/Deletar/5
        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var versao = await _context.Versao
                .Include(v => v.Sistema)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (versao == null)
            {
                return NotFound();
            }

            return View(versao);
        }

        // POST: Versoes/Deletar/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DelecaoConfirmada(int id)
        {
            var versao = await _context.Versao.FindAsync(id);
            _context.Versao.Remove(versao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Inicio), new { sistemaId = versao.SistemaId });
        }

        private bool VersaoExists(int id)
        {
            return _context.Versao.Any(e => e.Id == id);
        }
    }
}
