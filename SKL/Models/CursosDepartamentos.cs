using System;
using System.Collections.Generic;

namespace SKL.Models
{
    public partial class CursosDepartamentos
    {
        public DateTime Frequencia { get; set; }
        public int IdCursos { get; set; }
        public int IdDepartamentos { get; set; }

        public Cursos IdCursosNavigation { get; set; }
        public Departamentos IdDepartamentosNavigation { get; set; }
    }
}
