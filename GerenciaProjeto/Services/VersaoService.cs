using GerenciaProjeto.Data;
using GerenciaProjeto.Models;
using System;
using System.Linq;

namespace GerenciaProjeto.Services
{
    public class VersaoService
    {
        private readonly GerenciaProjetoContext _context;

        public VersaoService(GerenciaProjetoContext context)
        {
            _context = context;
        }

        public IQueryable<Versao> ListaVersoes(int idSistema, string pesquisa)
        {
            var result = from v in _context.Versao
                         where v.SistemaId == idSistema
                         select v;

            if (!String.IsNullOrEmpty(pesquisa))
            {
                result = result.Where(v => v.Nota.Contains(pesquisa));
            }

            return result.OrderByDescending(v => v.Data)
                         .OrderByDescending(v => v.Numero);
        }
    }
}
