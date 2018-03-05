using System;
using System.Collections.Generic;

namespace SKL.Models
{
    public partial class Questoes
    {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string E { get; set; }
        public string Correct { get; set; }
        public int IdQuestions { get; set; }
        public int IdCourses { get; set; }

        public Cursos IdCoursesNavigation { get; set; }
    }
}
