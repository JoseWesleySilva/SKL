using System;
using System.Collections.Generic;

namespace SKL.Models
{
    public partial class Empregados
    {
        public Empregados()
        {
            Departamentos = new HashSet<Departamentos>();
        }

        public int IdEmpregados { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string Curso { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Email { get; set; }
        public bool? Administrador { get; set; }
        public int IdCarogs { get; set; }
        public int IdDepartamentos { get; set; }

        public Cargos IdCarogsNavigation { get; set; }
        public Departamentos IdDepartamentosNavigation { get; set; }
        public ICollection<Departamentos> Departamentos { get; set; }
    }
}
