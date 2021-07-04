using GerenciaProjeto.Data;
using GerenciaProjeto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaProjeto.Services
{
    public class TarefaClienteService
    {
        private readonly GerenciaProjetoContext _context;

        public TarefaClienteService(GerenciaProjetoContext context)
        {
            _context = context;
        }

        public IQueryable<TarefaCliente> ListaTarefasPendentes(string ordenarPor, string pesquisa)
        {
            var result = _context.TarefaCliente
                .Include(t => t.Empresa)
                .Where(t => t.Status == Models.Enums.Status.Pendente);

            if (!String.IsNullOrEmpty(pesquisa))
            {
                result = result.Where(t => t.Empresa.Nome.Contains(pesquisa) ||
                                           t.Erro.Contains(pesquisa) ||
                                           t.Funcionario.Contains(pesquisa) ||
                                           t.Motivo.Contains(pesquisa) ||
                                           t.Solucao.Contains(pesquisa));
            }

            if (!String.IsNullOrEmpty(ordenarPor))
            {
                if (ordenarPor == "empresa")
                {
                    return result.OrderBy(t => t.Empresa.Nome);
                } else if (ordenarPor == "dataFinal")
                {
                    return result.OrderByDescending(t => t.DataFinal);
                }
            }

            return result
                .OrderByDescending(t => t.DataInicial);
        }

        public IQueryable<TarefaCliente> ListaTodasTarefas(string ordenarPor, string pesquisa)
        {
            var result = from t in _context.TarefaCliente
                         select t;

            if (!String.IsNullOrEmpty(pesquisa))
            {
                result = result.Where(t => t.Empresa.Nome.Contains(pesquisa) ||
                                           t.Erro.Contains(pesquisa) ||
                                           t.Funcionario.Contains(pesquisa) ||
                                           t.Motivo.Contains(pesquisa) ||
                                           t.Solucao.Contains(pesquisa));
            }

            result = result.Include(t => t.Empresa);

            if (!String.IsNullOrEmpty(ordenarPor))
            {
                if (ordenarPor == "empresa")
                {
                    return result.OrderBy(t => t.Empresa.Nome);
                }
                else if (ordenarPor == "dataFinal")
                {
                    return result.OrderByDescending(t => t.DataFinal);
                }
            }

            return result
                .OrderByDescending(t => t.DataInicial);
        }
    }
}
