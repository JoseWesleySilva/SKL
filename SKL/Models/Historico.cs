using System;
using System.Collections.Generic;

namespace SKL.Models
{
    public partial class Historico : Entidade
    {
        public int IdHistorico { get; set; }
        public DateTime? Data { get; set; }
        public float? Nota { get; set; }
        public int IdCurso { get; set; }
        public int IdEmpregado { get; set; }
    }
}
