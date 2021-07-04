using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaProjeto.Models.ViewModels
{
    public class EmpresaFormViewModel
    {
        public Empresa Empresa { get; set; }
        public ICollection<Sistema> Sistemas { get; set; }
        public List<int> SistemasSelecionados { get; set; }

        public EmpresaFormViewModel()
        {
            Sistemas = new HashSet<Sistema>();
            SistemasSelecionados = new List<int>();
        }
    }
}
