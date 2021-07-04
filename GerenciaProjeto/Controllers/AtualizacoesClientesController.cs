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
    public class AtualizacoesClientesController : Controller
    {
        private readonly GerenciaProjetoContext _context;
        private readonly AtualizacaoClienteService _atualizacaoClienteService;

        public AtualizacoesClientesController(GerenciaProjetoContext context, AtualizacaoClienteService atualizacaoClienteService)
        {
            _context = context;
            _atualizacaoClienteService = atualizacaoClienteService;
        }

        // GET: AtualizacoesClientes
        public async Task<IActionResult> Inicio(int? numeroPagina)
        {
            int _numeroPagina = numeroPagina ?? 1;

            ViewData["sistemas"] = await _context.Sistema.OrderBy(s => s.Nome).ToListAsync();
            return View(await PaginatedList<AtualizacaoCliente>.CreateAsync(_atualizacaoClienteService.ListaAtualizacoes(), _numeroPagina));
        }

        // GET: AtualizacoesClientes/Visualizar/5
        public async Task<IActionResult> Visualizar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atualizacoesClientes = await _context.AtualizacaoCliente
                .Include(a => a.Empresa)
                .Include(a => a.Sistema)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atualizacoesClientes == null)
            {
                return NotFound();
            }

            return View(atualizacoesClientes);
        }

        // GET: AtualizacoesClientes/Criar
        public IActionResult Criar(int sistemaId)
        {
            ViewData["EmpresaId"] = new SelectList(_context.Empresa.OrderBy(e => e.Nome), "Id", "Nome");
            ViewData["SistemaId"] = new SelectList(_context.Sistema.Where(s => s.Id == sistemaId), "Id", "Nome");
            ViewData["VersaoAnteriorId"] = new SelectList(_atualizacaoClienteService.ListaVersoesPorSistemaId(sistemaId), "Id", "Numero");
            ViewData["VersaoAtualizadaId"] = new SelectList(_atualizacaoClienteService.ListaVersoesPorSistemaId(sistemaId), "Id", "Numero");
            return View();
        }

        // POST: AtualizacoesClientes/Criar
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("Id,EmpresaId,Data,SistemaId,VersaoAnteriorId,VersaoAtualizadaId")] AtualizacaoCliente atualizacaoCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atualizacaoCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Inicio));
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresa.OrderBy(e => e.Nome), "Id", "Nome", atualizacaoCliente.EmpresaId);
            ViewData["SistemaId"] = new SelectList(_context.Sistema.OrderBy(s => s.Nome), "Id", "Nome", atualizacaoCliente.SistemaId);
            ViewData["VersaoAnteriorId"] = new SelectList(_atualizacaoClienteService.ListaVersoesPorSistemaId(atualizacaoCliente.SistemaId), "Id", "Numero");
            ViewData["VersaoAtualizadaId"] = new SelectList(_atualizacaoClienteService.ListaVersoesPorSistemaId(atualizacaoCliente.SistemaId), "Id", "Numero");
            return View(atualizacaoCliente);
        }

        // GET: AtualizacoesClientes/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atualizacaoCliente = await _context.AtualizacaoCliente.FindAsync(id);
            if (atualizacaoCliente == null)
            {
                return NotFound();
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresa.OrderBy(e => e.Nome), "Id", "Nome");
            ViewData["SistemaId"] = new SelectList(_context.Sistema.OrderBy(s => s.Nome), "Id", "Nome");
            ViewData["VersaoAnteriorId"] = new SelectList(_atualizacaoClienteService.ListaVersoesPorSistemaId(atualizacaoCliente.SistemaId), "Id", "Numero");
            ViewData["VersaoAtualizadaId"] = new SelectList(_atualizacaoClienteService.ListaVersoesPorSistemaId(atualizacaoCliente.SistemaId), "Id", "Numero");
            return View(atualizacaoCliente);
        }

        // POST: AtualizacoesClientes/Editar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,EmpresaId,Data,SistemaId,VersaoAnteriorId,VersaoAtualizadaId")] AtualizacaoCliente atualizacaoCliente)
        {
            if (id != atualizacaoCliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atualizacaoCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtualizacoesClientesExists(atualizacaoCliente.Id))
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
            ViewData["EmpresaId"] = new SelectList(_context.Empresa.OrderBy(e => e.Nome), "Id", "Nome", atualizacaoCliente.EmpresaId);
            ViewData["SistemaId"] = new SelectList(_context.Sistema.OrderBy(s => s.Nome), "Id", "Nome", atualizacaoCliente.SistemaId);
            ViewData["VersaoAnteriorId"] = new SelectList(_atualizacaoClienteService.ListaVersoesPorSistemaId(atualizacaoCliente.SistemaId), "Id", "Numero");
            ViewData["VersaoAtualizadaId"] = new SelectList(_atualizacaoClienteService.ListaVersoesPorSistemaId(atualizacaoCliente.SistemaId), "Id", "Numero");
            return View(atualizacaoCliente);
        }

        // GET: AtualizacoesClientes/Deletar/5
        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atualizacoesClientes = await _context.AtualizacaoCliente
                .Include(a => a.Empresa)
                .Include(a => a.Sistema)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atualizacoesClientes == null)
            {
                return NotFound();
            }

            return View(atualizacoesClientes);
        }

        // POST: AtualizacoesClientes/Deletar/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DelecaoConfirmada(int id)
        {
            var atualizacoesClientes = await _context.AtualizacaoCliente.FindAsync(id);
            _context.AtualizacaoCliente.Remove(atualizacoesClientes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Inicio));
        }

        public async Task<IActionResult> TodasAtualizacoes(int? numeroPagina, string ordenarPor)
        {
            int _numeroPagina = numeroPagina ?? 1;
            ViewData["ordenarPor"] = String.IsNullOrEmpty(ordenarPor) ? "empresa" : "";

            ViewData["sistemas"] = await _context.Sistema.OrderBy(s => s.Nome).ToListAsync();
            return View(await PaginatedList<AtualizacaoCliente>.CreateAsync(_atualizacaoClienteService.ListaAtualizacoes(ordenarPor), _numeroPagina));
        }

        public JsonResult ListaVersoes(int sistemaId)
        {
            var versoes = _atualizacaoClienteService.ListaVersoesPorSistemaId(sistemaId);

            var result = (from v in versoes
                          select new { id = v.Id, numero = v.Numero }
                         ).ToList();

            return Json(result);
        }

        private bool AtualizacoesClientesExists(int id)
        {
            return _context.AtualizacaoCliente.Any(e => e.Id == id);
        }
    }
}
