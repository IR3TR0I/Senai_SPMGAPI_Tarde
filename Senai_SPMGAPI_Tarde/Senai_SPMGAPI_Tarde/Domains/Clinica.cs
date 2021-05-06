using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Senai_SPMGAPI_Tarde.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }
        public int IdClinica { get; set; }
       
        [StringLength(maximumLength: 14, MinimumLength = 14, ErrorMessage = "O CNPJ precisa ter exatos 14 números!")]
        [Required(ErrorMessage ="O CNPJ é obrigatiorio para isso")]
        public string Cnpj { get; set; }

        [StringLength(maximumLength: 200, MinimumLength = 1, ErrorMessage = "O nome da empresa inserida é muito grande!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'nomeFantasia' obrigatório!")]
        public string NomeFantasia { get; set; }

        [StringLength(maximumLength: 200, MinimumLength = 1, ErrorMessage = "A razão social inserida é muito grande!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'razaoSocial' obrigatório!")]
        public string RazaoSocial { get; set; }

        [StringLength(maximumLength: 250, MinimumLength = 1, ErrorMessage = "O endereço inserido é muito grande!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'endereco' obrigatório!")]
        public string Endereço { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'horarioFuncionamento' obrigatório!")]
        public TimeSpan HorarioFuncionamento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'horarioFechamento' obrigatório!")]
        public TimeSpan HorarioFechamento { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
