using System;
using System.Collections.Generic;

namespace SKL.Models
{
    public partial class Curso : Entidade
    {
        public Curso()
        {
            CursosPorDepartamento = new HashSet<CursosPorDepartamento>();
            Questao = new HashSet<Questao>();
        }

        public int IdCurso { get; set; }
        public string TipoArquivo { get; set; }
        public string Nome { get; set; }
        public string LinkConteudo { get; set; }
        public string NomeAutor { get; set; }
        public DateTime? TempoEstimadoCurso { get; set; }

        public ICollection<CursosPorDepartamento> CursosPorDepartamento { get; set; }
        public ICollection<Questao> Questao { get; set; }
    }
}
