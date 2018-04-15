using System;
using System.Collections.Generic;

namespace SKL.Models
{
    public partial class Permissao : Entidade
    {
        public Permissao()
        {
            Login = new HashSet<Login>();
        }

        public int IdPermissao { get; set; }
        public byte[] Admin { get; set; }
        public byte[] Gerente { get; set; }
        public byte[] Usuario { get; set; }

        public ICollection<Login> Login { get; set; }
    }
}
