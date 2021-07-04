using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaProjeto.Models
{
    public partial class Sistema
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Versao> Versoes { get; set; }
        public virtual ICollection<Empresa> Empresas { get; set; }

        public Sistema()
        {
            Versoes = new HashSet<Versao>();
            Empresas = new HashSet<Empresa>();
        }
    }
}
