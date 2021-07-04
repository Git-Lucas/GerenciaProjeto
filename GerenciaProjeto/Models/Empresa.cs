using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GerenciaProjeto.Models
{
    public partial class Empresa
    {
        public int Id { get; set; }

        [Display(Name = "CNPJ")]
        [Remote(action: "CnpjExiste", controller: "Empresas", AdditionalFields = "Id")]
        public string Cnpj { get; set; }

        public string Nome { get; set; }
        public string Telefone { get; set; }
        public virtual ICollection<Sistema> Sistemas { get; set; }
        public virtual ICollection<TarefaCliente> TarefasCliente { get; set; }

        public Empresa()
        {
            TarefasCliente = new HashSet<TarefaCliente>();
            Sistemas = new HashSet<Sistema>();
        }
    }
}
