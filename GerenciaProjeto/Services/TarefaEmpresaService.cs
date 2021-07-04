using GerenciaProjeto.Data;
using GerenciaProjeto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaProjeto.Services
{
    public class TarefaEmpresaService
    {
        private readonly GerenciaProjetoContext _context;

        public TarefaEmpresaService(GerenciaProjetoContext context)
        {
            _context = context;
        }

        public IQueryable<TarefaEmpresa> ListaTarefasPendentes(string pesquisa)
        {
            var result = _context.TarefaEmpresa
                .Where(t => t.Status == Models.Enums.Status.Pendente);

            if (!String.IsNullOrEmpty(pesquisa)) {
                result = result.Where(t =>  t.Acao.Contains(pesquisa) ||
                                            t.Observacao.Contains(pesquisa));
            }

            return result
                .OrderByDescending(t => t.DataInicial);
        }

        public IQueryable<TarefaEmpresa> ListaTodasTarefas(string pesquisa)
        {
            var result = from te in _context.TarefaEmpresa
                         select te;

            if (!String.IsNullOrEmpty(pesquisa))
            {
                result = result.Where(t => t.Acao.Contains(pesquisa) ||
                                            t.Observacao.Contains(pesquisa));
            }

            return result
                .OrderByDescending(t => t.DataInicial);
        }
    }
}
