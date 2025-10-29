using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smartCampos.Models
{
    public class objUsuario
    {
        public int idUsuario { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public DateTime dta_Cadastro { get; set; }
    }
}