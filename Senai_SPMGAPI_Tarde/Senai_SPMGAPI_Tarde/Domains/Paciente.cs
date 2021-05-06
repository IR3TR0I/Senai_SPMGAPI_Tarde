using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Senai_SPMGAPI_Tarde.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdPaciente { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O paciente precisa ter uma conta!")]
        public int? IdUsuario { get; set; }

        [StringLength(maximumLength: 250, MinimumLength = 1, ErrorMessage = "O nome do paciente inserido é muito grande!")]
        [RegularExpression("^[a-zA-Z ç ~ ã õ ê â î ô ñ û ú í á é ó ü ï ä ö ë]+$", ErrorMessage = "O nome do paciente deve conter apenas letras!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'nomePaciente' obrigatório!")]
        public string NomePaciente { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "O RG deve conter apenas números!")]
        [StringLength(maximumLength: 9, MinimumLength = 9, ErrorMessage = "O RG precisa ter exatos 9 números!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O paciente precisa ter um RG!")]
        public string Rg { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "O CPF deve conter apenas números!")]
        [StringLength(maximumLength: 11, MinimumLength = 11, ErrorMessage = "O CPF precisa ter exatos 11 números!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O paciente precisa ter um CPF!")]
        public string Cpf { get; set; }

        [RegularExpression("^(0[1-9]|[12][0-9]|3[01])[/](0[1-9]|1[012])[/](19|20)[0-9][0-9](( )([0-9][0-9][:]){2}[0-9][0-9])?", ErrorMessage = "Por favor, preencha o campo no formato: dd/mm/yyyy!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "O valor inserido não é uma data válida!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O Paciente precisa de uma data de nascimento")]
        public DateTime DataNascimento { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(maximumLength: 11, MinimumLength = 11, ErrorMessage = "O número de telefone precisa ter exatos 11 números!")]
        public string TelefonePaciente { get; set; }

        [StringLength(maximumLength: 250, MinimumLength = 1, ErrorMessage = "O endereço inserido é muito grande!")]
        public string Endereço { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
