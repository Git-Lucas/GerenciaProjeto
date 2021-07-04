using GerenciaProjeto.Data;
using GerenciaProjeto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GerenciaProjeto.Services
{
    public class EmpresaService
    {
        private readonly GerenciaProjetoContext _context;

        public EmpresaService(GerenciaProjetoContext context)
        {
            _context = context;
        }

        public IQueryable<Empresa> ListaEmpresas(string pesquisa)
        {
            var result = from e in _context.Empresa
                         select e;

            if (!String.IsNullOrEmpty(pesquisa))
            {
                result = result.Where(e =>  e.Nome.Contains(pesquisa) ||
                                            e.Telefone.Contains(pesquisa));
            }

            return result.OrderBy(e => e.Nome);
        }

        public IQueryable<Empresa> ListaEmpresasPorSistema(int? sistemaId, string pesquisa)
        {
            var result = from e in _context.Empresa
                         select e;

            var sistema = _context.Sistema.FirstOrDefault(s => s.Id == sistemaId);
            result = result.Where(e => e.Sistemas.Contains(sistema));

            if (!String.IsNullOrEmpty(pesquisa))
            {
                result = result.Where(e => e.Nome.Contains(pesquisa) ||
                                            e.Telefone.Contains(pesquisa));
            }

            return result.OrderBy(e => e.Nome);
        }

        public async Task<bool> CnpjExisteAsync(string cnpj, int? id)
        {
            cnpj = Regex.Replace(cnpj, "[^0-9]", "");
            var result = await _context.Empresa.FirstOrDefaultAsync(obj => obj.Cnpj == cnpj);
            if (result == null || result.Id == id.Value)
            {
                return false;
            }
            return true;
        }
    }
}
