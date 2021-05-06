using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Senai_SPMGAPI_Tarde.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdMedico { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "O médico precisa ter uma conta!")]
        public int? Idusuario { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O médico precisa estar numa clínica!")]
        public int? IdClinica { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O médico precisa ter uma especialidade!")]
        public int? IdEspecialidades { get; set; }

        [StringLength(maximumLength: 250, MinimumLength = 1, ErrorMessage = "O nome do médico inserido é muito grande!")]
        [RegularExpression("^[a-zA-Z ç ~ ã õ ê â î ô ñ û ú í á é ó ü ï ä ö ë]+$", ErrorMessage = "O nome do médico deve conter apenas letras!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'nomeMedico' obrigatório!")]
        public string NomeMedico { get; set; }

        [StringLength(maximumLength: 7, MinimumLength = 7, ErrorMessage = "O CRM precisa ter exatos 7 caracteres!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O médico precisa ter um CRM!")]
        public string Crm { get; set; }

        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Especialidade IdEspecialidadesNavigation { get; set; }
        public virtual Usuario IdusuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
