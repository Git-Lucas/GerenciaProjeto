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
    public class TarefasClientesController : Controller
    {
        private readonly GerenciaProjetoContext _context;
        private readonly TarefaClienteService _tarefaClienteService;
        private readonly EmpresaService _empresaService;

        public TarefasClientesController(GerenciaProjetoContext context, TarefaClienteService tarefaClienteService, EmpresaService empresaService)
        {
            _context = context;
            _tarefaClienteService = tarefaClienteService;
            _empresaService = empresaService;
        }

        // GET: TarefaClientes
        public async Task<IActionResult> Inicio(string ordenarPor, int? numeroPagina, string pesquisa)
        {
            ViewData["ordenarPor"] = ordenarPor;
            int _numeroPagina = numeroPagina ?? 1;
            ViewData["pesquisa"] = pesquisa;

            var tarefasClientes = _tarefaClienteService.ListaTarefasPendentes(ordenarPor, pesquisa);
            ViewData["Title"] = $"Tarefas Cliente ({tarefasClientes.Count()} Pendentes)";

            return View(await PaginatedList<TarefaCliente>.CreateAsync(tarefasClientes, _numeroPagina));
        }

        public async Task<IActionResult> TodasTarefas(string ordenarPor, int? numeroPagina, string pesquisa)
        {
            ViewData["ordenarPor"] = ordenarPor;
            int _numeroPagina = numeroPagina ?? 1;
            ViewData["pesquisa"] = pesquisa;

            return View(await PaginatedList<TarefaCliente>.CreateAsync(_tarefaClienteService.ListaTodasTarefas(ordenarPor, pesquisa), _numeroPagina));
        }

        // GET: TarefaClientes/Visualizar/5
        public async Task<IActionResult> Visualizar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefaCliente = await _context.TarefaCliente
                .Include(t => t.Empresa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarefaCliente == null)
            {
                return NotFound();
            }

            return View(tarefaCliente);
        }

        // GET: TarefaClientes/Criar
        public IActionResult Criar()
        {
            ViewData["EmpresaId"] = new SelectList(_context.Empresa.OrderBy(e => e.Nome), "Id", "Nome");
            return View();
        }

        // POST: TarefaClientes/Criar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("Id,Funcionario,EmpresaId,Erro,Motivo,Solucao,Status,DataInicial,DataFinal")] TarefaCliente tarefaCliente)
        {
            if (ModelState.IsValid)
            {
                tarefaCliente.DataInicial = DateTime.Now;
                if (tarefaCliente.Status == Models.Enums.Status.Feito && !tarefaCliente.DataFinal.HasValue)
                {
                    tarefaCliente.DataFinal = DateTime.Now;
                }
                _context.Add(tarefaCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Inicio));
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "Id", "Nome", tarefaCliente.EmpresaId);
            return View(tarefaCliente);
        }

        // GET: TarefaClientes/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefaCliente = await _context.TarefaCliente.FindAsync(id);
            if (tarefaCliente == null)
            {
                return NotFound();
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "Id", "Nome", tarefaCliente.EmpresaId);
            return View(tarefaCliente);
        }

        // POST: TarefaClientes/Editar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,Funcionario,EmpresaId,Erro,Motivo,Solucao,Status,DataInicial,DataFinal")] TarefaCliente tarefaCliente)
        {
            if (id != tarefaCliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (tarefaCliente.Status == Models.Enums.Status.Feito && !tarefaCliente.DataFinal.HasValue)
                    {
                        tarefaCliente.DataFinal = DateTime.Now;
                    }
                    _context.Update(tarefaCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarefaClienteExists(tarefaCliente.Id))
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
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "Id", "Nome", tarefaCliente.EmpresaId);
            return View(tarefaCliente);
        }

        // GET: TarefaClientes/Deletar/5
        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefaCliente = await _context.TarefaCliente
                .Include(t => t.Empresa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarefaCliente == null)
            {
                return NotFound();
            }

            return View(tarefaCliente);
        }

        // POST: TarefaClientes/Deletar/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DelecaoConfirmada(int id)
        {
            var tarefaCliente = await _context.TarefaCliente.FindAsync(id);
            _context.TarefaCliente.Remove(tarefaCliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Inicio));
        }

        private bool TarefaClienteExists(int id)
        {
            return _context.TarefaCliente.Any(e => e.Id == id);
        }
    }
}
