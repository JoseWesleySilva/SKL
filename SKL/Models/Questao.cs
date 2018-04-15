using System;
using System.Collections.Generic;

namespace SKL.Models
{
    public partial class Questao : Entidade
    {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string E { get; set; }
        public string Correct { get; set; }
        public int IdQuestao { get; set; }
        public int IdCurso { get; set; }

        public Curso IdCursoNavigation { get; set; }
    }
}
