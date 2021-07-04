using GerenciaProjeto.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GerenciaProjeto.Models
{
    public partial class TarefaCliente
    {
        public int Id { get; set; }

        [Display(Name = "Funcionário")]
        public string Funcionario { get; set; }

        public Empresa Empresa { get; set; }

        [Display(Name = "Empresa")]
        public int EmpresaId { get; set; }
        public string Erro { get; set; }
        public string Motivo { get; set; }

        [Display(Name = "Solução")]
        public string Solucao { get; set; }

        public Status Status { get; set; }

        [Display(Name = "Data Inicial")]
        [DataType(DataType.Date)]
        public DateTime? DataInicial { get; set; }

        [Display(Name = "Data Final")]
        [DataType(DataType.Date)]
        public DateTime? DataFinal { get; set; }
    }
}
