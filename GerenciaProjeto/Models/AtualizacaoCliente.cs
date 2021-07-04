using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaProjeto.Models
{
    public partial class AtualizacaoCliente
    {
        public int Id { get; set; }
        public Empresa Empresa { get; set; }

        [Required(ErrorMessage = "'{0}' é um campo obrigatório.")]
        [Display(Name = "Empresa")]
        public int EmpresaId { get; set; }

        public Sistema Sistema { get; set; }

        [Required(ErrorMessage = "'{0}' é um campo obrigatório.")]
        [Display(Name = "Sistema")]
        public int SistemaId { get; set; }

        [Display(Name = "Versão Anterior")]
        public Versao VersaoAnterior { get; set; }


        [Display(Name = "Versão Anterior")]
        public int? VersaoAnteriorId { get; set; }

        [Display(Name = "Versão Atualizada")]
        public Versao VersaoAtualizada { get; set; }

        [Required(ErrorMessage = "'{0}' é um campo obrigatório.")]
        [Display(Name = "Versão Atualizada")]
        public int VersaoAtualizadaId { get; set; }

        [Required(ErrorMessage = "'{0}' é um campo obrigatório.")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
    }
}
