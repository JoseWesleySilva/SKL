using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SKL.Models
{
    public partial class Login : Entidade
    {
        public int IdLogin { get; set; }
        
        [DisplayName("Nome"), Required(ErrorMessage = "Campo Nome deve ser preenchido.") ]
        [StringLength(50, ErrorMessage = "Campo Nome deve conter no maxímo 50 caracteres.")]
        [RegularExpression(@"^[A-z0-9]*$", ErrorMessage = "Campo Nome deve ser preenchido apenas com letras e números.")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Campo Senha deve ser prenchido.")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Campo Senha deve conter no minimo 8 e no máximo 20 caracteres.")]
        public string Senha { get; set; }
        public int IdPermissao { get; set; }
        public Permissao Permissao { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}
