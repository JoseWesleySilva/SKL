using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SKL.Models
{
    public partial class Login : Entidade
    {
        public Login()
        {
            Pessoas = new HashSet<Pessoas>();
        }

        public int IdLogin { get; set; }

        [Required]
        [DisplayName("Nome")]
        public string NomeUsuario { get; set; }

        [Required]
        public string Senha { get; set; }

        public int IdPermissao { get; set; }

        public Permissoes IdPermissaoNavigation { get; set; }

        public ICollection<Pessoas> Pessoas { get; set; }
    }
}
