using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Senai_SPMGAPI_Tarde.Domains
{
    public partial class Situações
    {
        public Situações()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdSituação { get; set; }

        [Required(ErrorMessage = "Campo 'situação' obrigatório!")]
        public string TituloSituação { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
