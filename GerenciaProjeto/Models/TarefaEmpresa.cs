using GerenciaProjeto.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GerenciaProjeto.Models
{
    public partial class TarefaEmpresa
    {
        public int Id { get; set; }

        [Display(Name = "Ação")]
        public string Acao { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        public Status Status { get; set; }

        [Display(Name = "Data Inicial")]
        [DataType(DataType.Date)]
        public DateTime? DataInicial { get; set; }

        [Display(Name = "Data Final")]
        [DataType(DataType.Date)]
        public DateTime? DataFinal { get; set; }
    }
}
