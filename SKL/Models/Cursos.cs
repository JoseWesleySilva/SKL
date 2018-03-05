using System;
using System.Collections.Generic;

namespace SKL.Models
{
    public partial class Cursos
    {
        public Cursos()
        {
            CursosDepartamentos = new HashSet<CursosDepartamentos>();
            Questoes = new HashSet<Questoes>();
        }

        public int IdCursos { get; set; }
        public string TipoArquivo { get; set; }
        public string Nome { get; set; }
        public string LinkConteudo { get; set; }
        public string NomeAutor { get; set; }
        public DateTime? TempoEstimadoCurso { get; set; }

        public ICollection<CursosDepartamentos> CursosDepartamentos { get; set; }
        public ICollection<Questoes> Questoes { get; set; }
    }
}
