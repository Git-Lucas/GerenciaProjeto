using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaProjeto.Models.ViewModels
{
    public class VersaoViewModel
    {
        public ICollection<Versao> Versoes { get; set; }
        public ICollection<AtualizacaoCliente> AtualizacoesClientes { get; set; }

        public VersaoViewModel()
        {
            Versoes = new HashSet<Versao>();
            AtualizacoesClientes = new HashSet<AtualizacaoCliente>();
        }
    }
}
