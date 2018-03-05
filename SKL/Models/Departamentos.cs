using System;
using System.Collections.Generic;

namespace SKL.Models
{
    public partial class Departamentos
    {
        public Departamentos()
        {
            CursosDepartamentos = new HashSet<CursosDepartamentos>();
            Empregados = new HashSet<Empregados>();
        }

        public int IdDepartamentos { get; set; }
        public string Nome { get; set; }
        public int IdEmpregados { get; set; }

        public Empregados IdEmpregadosNavigation { get; set; }
        public ICollection<CursosDepartamentos> CursosDepartamentos { get; set; }
        public ICollection<Empregados> Empregados { get; set; }
    }
}
