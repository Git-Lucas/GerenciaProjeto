using GerenciaProjeto.Data;
using GerenciaProjeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GerenciaProjeto.Services
{
    public class AtualizacaoClienteService
    {
        private readonly GerenciaProjetoContext _context;

        public AtualizacaoClienteService(GerenciaProjetoContext context)
        {
            _context = context;
        }

        public IQueryable<AtualizacaoCliente> ListaAtualizacoes()
        {
            var result = from a in _context.AtualizacaoCliente
                         select a;

            result = result.Where(a => a.Empresa.Sistemas.Contains(a.Sistema));
            result = result.Where(a => a.VersaoAtualizada != a.Sistema.Versoes.OrderByDescending(v => v.Data).First());

            return result
                .Include(a => a.Empresa)
                .Include(a => a.Sistema)
                .Include(a => a.Sistema.Versoes)
                .Include(a => a.VersaoAnterior)
                .Include(a => a.VersaoAtualizada)
                .OrderByDescending(a => a.Data);
        }

        public IQueryable<AtualizacaoCliente> ListaAtualizacoes(string ordenarPor)
        {
            var result = _context.AtualizacaoCliente
                .Include(a => a.Empresa)
                .Include(a => a.Sistema)
                .Include(a => a.Sistema.Versoes)
                .Include(a => a.VersaoAnterior)
                .Include(a => a.VersaoAtualizada);

            if (!String.IsNullOrEmpty(ordenarPor))
            {
                if (ordenarPor == "empresa")
                {
                    return result
                        .OrderByDescending(a => a.Data)
                        .OrderBy(a => a.Empresa.Nome);
                }
            }

            return result
                .OrderByDescending(a => a.Data);
        }

        public List<Versao> ListaVersoesPorSistemaId(int sistemaId)
        {
            var sistema = _context.Sistema.Include(s => s.Versoes).FirstOrDefault(s => s.Id == sistemaId);

            var versoes = sistema.Versoes.OrderByDescending(v => v.Data).ToList();

            return versoes;
        }
    }
}
