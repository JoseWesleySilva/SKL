using System;
using System.Collections.Generic;

namespace SKL.Models
{
    public partial class CursosPorDepartamento : Entidade
    {
        public int IdCurso { get; set; }
        public int IdDepartamento { get; set; }

        public Curso IdCursoNavigation { get; set; }
        public Departamento IdDepartamentoNavigation { get; set; }
    }
}
