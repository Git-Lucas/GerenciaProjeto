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
    public class TarefasEmpresaController : Controller
    {
        private readonly GerenciaProjetoContext _context;
        private readonly TarefaEmpresaService _tarefaEmpresaService;

        public TarefasEmpresaController(GerenciaProjetoContext context, TarefaEmpresaService tarefaEmpresaService)
        {
            _context = context;
            _tarefaEmpresaService = tarefaEmpresaService;
        }

        // GET: TarefaEmpresas
        public async Task<IActionResult> Inicio(int? numeroPagina, string pesquisa)
        {
            int _numeroPagina = numeroPagina ?? 1;
            ViewData["pesquisa"] = pesquisa;

            var tarefasEmpresa = _tarefaEmpresaService.ListaTarefasPendentes(pesquisa);
            ViewData["Title"] = $"Tarefas Empresa ({tarefasEmpresa.Count()} Pendentes)";
            
            return View(await PaginatedList<TarefaEmpresa>.CreateAsync(tarefasEmpresa, _numeroPagina));
        }

        public async Task<IActionResult> TodasTarefas(int? numeroPagina, string pesquisa)
        {
            int _numeroPagina = numeroPagina ?? 1;
            ViewData["pesquisa"] = pesquisa;

            return View(await PaginatedList<TarefaEmpresa>.CreateAsync(_tarefaEmpresaService.ListaTodasTarefas(pesquisa), _numeroPagina));
        }

        // GET: TarefaEmpresas/Visualizar/5
        public async Task<IActionResult> Visualizar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefaEmpresa = await _context.TarefaEmpresa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarefaEmpresa == null)
            {
                return NotFound();
            }

            return View(tarefaEmpresa);
        }

        // GET: TarefaEmpresas/Criar
        public IActionResult Criar()
        {
            return View();
        }

        // POST: TarefaEmpresas/Criar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("Id,Acao,Observacao,Status,Datainicial,Datafinal")] TarefaEmpresa tarefaEmpresa)
        {
            if (ModelState.IsValid)
            {
                tarefaEmpresa.DataInicial = DateTime.Now;
                if (tarefaEmpresa.Status == Models.Enums.Status.Feito && !tarefaEmpresa.DataFinal.HasValue)
                {
                    tarefaEmpresa.DataFinal = DateTime.Now;
                }
                _context.Add(tarefaEmpresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Inicio));
            }
            return View(tarefaEmpresa);
        }

        // GET: TarefaEmpresas/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefaEmpresa = await _context.TarefaEmpresa.FindAsync(id);
            if (tarefaEmpresa == null)
            {
                return NotFound();
            }
            return View(tarefaEmpresa);
        }

        // POST: TarefaEmpresas/Editar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,Acao,Observacao,Status,DataInicial,DataFinal")] TarefaEmpresa tarefaEmpresa)
        {
            if (id != tarefaEmpresa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (tarefaEmpresa.Status == Models.Enums.Status.Feito && !tarefaEmpresa.DataFinal.HasValue)
                    {
                        tarefaEmpresa.DataFinal = DateTime.Now;
                    }
                    _context.Update(tarefaEmpresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarefaEmpresaExists(tarefaEmpresa.Id))
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
            return View(tarefaEmpresa);
        }

        // GET: TarefaEmpresas/Deletar/5
        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefaEmpresa = await _context.TarefaEmpresa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarefaEmpresa == null)
            {
                return NotFound();
            }

            return View(tarefaEmpresa);
        }

        // POST: TarefaEmpresas/Deletar/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DelecaoConfirmada(int id)
        {
            var tarefaEmpresa = await _context.TarefaEmpresa.FindAsync(id);
            _context.TarefaEmpresa.Remove(tarefaEmpresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Inicio));
        }

        private bool TarefaEmpresaExists(int id)
        {
            return _context.TarefaEmpresa.Any(e => e.Id == id);
        }
    }
}
