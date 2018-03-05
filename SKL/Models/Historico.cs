using System;
using System.Collections.Generic;

namespace SKL.Models
{
    public partial class Historico
    {
        public DateTime? Datas { get; set; }
        public float? Notas { get; set; }
        public int IdCursos { get; set; }
        public int IdEmpregados { get; set; }
    }
}
