using System;
using System.Collections.Generic;

namespace SKL.Models
{
    public partial class Departamento : Entidade
    {
        public Departamento()
        {
            CursosPorDepartamento = new HashSet<CursosPorDepartamento>();
            Empregado = new HashSet<Empregado>();
        }

        public int IdDepartamento { get; set; }
        public string Nome { get; set; }
        public int IdEmpregado { get; set; }

        public Empregado IdEmpregadoNavigation { get; set; }
        public ICollection<CursosPorDepartamento> CursosPorDepartamento { get; set; }
        public ICollection<Empregado> Empregado { get; set; }
    }
}
