using System;
using System.Collections.Generic;

namespace SKL.Models
{
    public partial class Pessoas
    {
        public int IdPessoas { get; set; }
        public string Nome { get; set; }
        public int IdLogin { get; set; }

        public Login IdLoginNavigation { get; set; }
    }
}
