using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaProjeto.Models.ViewModels
{
    public class VersaoFormViewModel
    {
        public Versao Versao{ get; set; }
        public ICollection<Sistema> Sistemas { get; set; }

        public VersaoFormViewModel()
        {
            Sistemas = new HashSet<Sistema>();
        }
    }
}
