using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaProjeto.Models
{
    public partial class Versao
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "'{0}' é um campo obrigatório.")]
        [Display(Name = "Número")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "'{0}' é um campo obrigatório.")]
        [DataType(DataType.Date)]
        [Display(Name = "Data Lançamento")]
        public DateTime Data { get; set; }

        public string Nota { get; set; }
        public Sistema Sistema { get; set; }

        [Display(Name = "Sistema")]
        public int SistemaId { get; set; }
    }
}
