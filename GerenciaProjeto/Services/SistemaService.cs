using GerenciaProjeto.Data;
using GerenciaProjeto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaProjeto.Services
{
    public class SistemaService
    {
        private readonly GerenciaProjetoContext _context;

        public SistemaService(GerenciaProjetoContext context)
        {
            _context = context;
        }

        public IQueryable<Sistema> ListaSistemas(string pesquisa)
        {
            var result = from s in _context.Sistema
                         select s;

            if (!String.IsNullOrEmpty(pesquisa))
            {
                result = result.Where(s => s.Nome.Contains(pesquisa));
            }
            
            return result.Include(s => s.Versoes)
                         .OrderBy(s => s.Nome);
        }
    }
}
