using System;
using System.Collections.Generic;

namespace SKL.Models
{
    public partial class Cargo : Entidade
    {
        public Cargo()
        {
            Empregado = new HashSet<Empregado>();
        }

        public int IdCargo { get; set; }
        public DateTime? Frequencia { get; set; }
        public DateTime? TempoCursado { get; set; }

        public ICollection<Empregado> Empregado { get; set; }
    }
}
