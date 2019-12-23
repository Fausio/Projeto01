using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projeto01.Areas.Seguranca.Data
{
    public class UsuarioViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        public string Email { get; set; }


        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Senha { get; set; }
    }
}