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
using System.Text.RegularExpressions;
using GerenciaProjeto.Models.ViewModels;

namespace GerenciaProjeto.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly GerenciaProjetoContext _context;
        private readonly EmpresaService _empresaService;

        public EmpresasController(GerenciaProjetoContext context, EmpresaService empresaService)
        {
            _context = context;
            _empresaService = empresaService;
        }

        // GET: Empresas
        public async Task<IActionResult> Inicio(int? sistemaId, int? numeroPagina, string pesquisa)
        {
            int _numeroPagina = numeroPagina ?? 1;
            ViewData["pesquisa"] = pesquisa;
            ViewData["sistemaId"] = sistemaId;

            if (sistemaId == null)
            {
                ViewData["Title"] = "Empresas";
                return View(await PaginatedList<Empresa>.CreateAsync(_empresaService.ListaEmpresas(pesquisa), _numeroPagina));
            } else
            {
                Sistema sistema = await _context.Sistema.FindAsync(sistemaId);
                ViewData["Title"] = $"Empresas que possuem o {sistema.Nome}";
                return View(await PaginatedList<Empresa>.CreateAsync(_empresaService.ListaEmpresasPorSistema(sistemaId, pesquisa), _numeroPagina));
            }
        }

        // GET: Empresas/Visualizar/5
        public async Task<IActionResult> Visualizar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresa.FirstOrDefaultAsync(m => m.Id == id);

            if (empresa == null)
            {
                return NotFound();
            }

            List<Sistema> sistemas = await _context.Sistema.Where(s => s.Empresas.Contains(empresa))
                                                                   .ToListAsync();
            EmpresaFormViewModel viewModel = new() { Empresa = empresa, Sistemas = sistemas };
            return View(viewModel);
        }

        // GET: Empresas/Criar
        public async Task<IActionResult> Criar()
        {
            List<Sistema> sistemas = await _context.Sistema.OrderBy(s => s.Nome)
                                                           .ToListAsync();
            EmpresaFormViewModel viewModel = new() { Sistemas = sistemas };
            return View(viewModel);
        }

        // POST: Empresas/Criar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("Id,Cnpj,Nome,Telefone")] Empresa empresa, [Bind("Empresa.Sistemas")] int[] sistemas)
        {
            if (ModelState.IsValid)
            {
                if (!String.IsNullOrEmpty(empresa.Cnpj))
                {
                    empresa.Cnpj = Regex.Replace(empresa.Cnpj, "[^0-9]", "");
                }

                foreach (var idSistema in sistemas)
                {
                    var sistema = _context.Sistema.Find(idSistema);
                    empresa.Sistemas.Add(sistema);
                }

                _context.Add(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Inicio));
            }
            return View(empresa);
        }

        // GET: Empresas/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresa.FindAsync(id);

            if (empresa == null)
            {
                return NotFound();
            }

            List<Sistema> sistemas = await _context.Sistema.OrderBy(s => s.Nome)
                                                           .ToListAsync();
            List<int> sistemasSelecionados = await _context.Sistema.Where(s => s.Empresas.Contains(empresa))
                                                                   .Select(s => s.Id)
                                                                   .ToListAsync();
            EmpresaFormViewModel viewModel = new() { Empresa = empresa, Sistemas = sistemas, SistemasSelecionados = sistemasSelecionados };
            return View(viewModel);
        }

        // POST: Empresas/Editar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,Cnpj,Nome,Telefone")] Empresa empresa, [Bind("Empresa.Sistemas")] int[] sistemas)
        {
            if (id != empresa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var empresaSistema = await _context.Empresa.Include(e => e.Sistemas).SingleAsync(s => s.Id == id);
                    

                    if (!String.IsNullOrEmpty(empresaSistema.Cnpj))
                    {
                        empresaSistema.Cnpj = Regex.Replace(empresaSistema.Cnpj, "[^0-9]", "");
                    }

                    empresaSistema.Sistemas.Clear();
                    foreach (var idSistema in sistemas)
                    {
                        var sistema = _context.Sistema.Find(idSistema);
                        empresaSistema.Sistemas.Add(sistema);
                    }

                    empresaSistema.Cnpj = empresa.Cnpj;
                    empresaSistema.Nome = empresa.Nome;
                    empresaSistema.Telefone = empresa.Telefone;

                    _context.Update(empresaSistema);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaExists(empresa.Id))
                    {
                        return NotFound();
                    } else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Inicio));
            }
            return View(empresa);
        }

        // GET: Empresas/Deletar/5
        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empresa == null)
            {
                return NotFound();
            }

            List<Sistema> sistemas = await _context.Sistema.Where(s => s.Empresas.Contains(empresa))
                                                                   .ToListAsync();
            EmpresaFormViewModel viewModel = new() { Empresa = empresa, Sistemas = sistemas };
            return View(viewModel);
        }

        // POST: Empresas/Deletar/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DelecaoConfirmada(int id)
        {
            var empresa = await _context.Empresa.FindAsync(id);
            _context.Empresa.Remove(empresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Inicio));
        }

        private bool EmpresaExists(int id)
        {
            return _context.Empresa.Any(e => e.Id == id);
        }

        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        public async Task<IActionResult> CnpjExiste([Bind(Prefix = "Empresa.Cnpj")] string Cnpj, [Bind(Prefix = "Empresa.Id")] int Id)
        {
            if (await _empresaService.CnpjExisteAsync(Cnpj, Id))
            {
                return Json($"CNPJ já cadastrado.");
            }
            return Json(true);
        }
    }
}