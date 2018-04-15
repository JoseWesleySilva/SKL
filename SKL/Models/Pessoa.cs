using System;
using System.Collections.Generic;

namespace SKL.Models
{
    public partial class Pessoa : Entidade
    {
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public int IdLogin { get; set; }

        public Login IdLoginNavigation { get; set; }
    }
}
