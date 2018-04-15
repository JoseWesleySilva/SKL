using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SKL.Models
{
    public partial class Login : Entidade
    {
        public Login()
        {
            Pessoa = new HashSet<Pessoa>();
        }

        public int IdLogin { get; set; }

        [StringLength(50)]
        [DisplayName("Nome")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required(ErrorMessage = "O campo Nome deve ser preenchido.")]
        public string NomeUsuario { get; set; }

        [StringLength(50, MinimumLength = 8)]
        [Required(ErrorMessage = "O campo Senha deve ser preenchido.")]
        public string Senha { get; set; }
        public int IdPermissao { get; set; }

        public Permissao IdPermissaoNavigation { get; set; }
        public ICollection<Pessoa> Pessoa { get; set; }
    }
}
