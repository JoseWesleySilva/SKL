using SKL.Models;
using System.Collections.Generic;
using System.Text;

namespace SKL.Util
{
    public class Resultado
    {
        public StringBuilder MensagemErro { get; set; }
        public StringBuilder MensagemSucesso { get; set; }
        public List<Entidade> ListaResultados { get; set; }
    }
}
