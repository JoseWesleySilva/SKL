using System;
using System.Collections.Generic;

namespace SKL.Models
{
    public partial class Cargos : Entidade
    {
        public Cargos()
        {
            Empregados = new HashSet<Empregados>();
        }

        public int IdCargos { get; set; }
        public DateTime? Frequencia { get; set; }
        public DateTime? TempoCursado { get; set; }

        public ICollection<Empregados> Empregados { get; set; }
    }
}
