using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SKL.Models;
using SKL.Util;

namespace SKL.Strategy.StrategyImpl
{
    public class LoginStrategy : IStrategy
    {
        private Login Login { get; set; }

        public Resultado Resultado
        {
            get { return Resultado; }
            set { Resultado = value; }
        }


        public Resultado ValidaEntidade(Entidade entidade)
        {
            Login = (Login)entidade;
            Resultado = new Resultado();
            Resultado.MensagemSucesso.Append("Validado com sucesso.");
            return Resultado;
        }
    }
}
