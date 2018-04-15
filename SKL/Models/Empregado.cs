using System;
using System.Collections.Generic;

namespace SKL.Models
{
    public partial class Empregado : Entidade
    {
        public Empregado()
        {
            Departamento = new HashSet<Departamento>();
        }

        public int IdEmpregado { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string Curso { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Email { get; set; }
        public bool? Administrador { get; set; }
        public int IdCargo { get; set; }
        public int IdDepartamento { get; set; }

        public Cargo IdCargoNavigation { get; set; }
        public Departamento IdDepartamentoNavigation { get; set; }
        public ICollection<Departamento> Departamento { get; set; }
    }
}
