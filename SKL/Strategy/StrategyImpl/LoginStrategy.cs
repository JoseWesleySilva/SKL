using SKL.Models;
using SKL.Util;

namespace SKL.Strategy.StrategyImpl
{
    public class LoginStrategy : AbstractStrategy
    {
        private Login Login { get; set; }

        public override Resultado ValidaEntidade(Entidade entidade)
        {
            Login = (Login)entidade;
            Resultado.MensagemSucesso.Append("Validado com sucesso.");
            return Resultado;
        }
    }
}
