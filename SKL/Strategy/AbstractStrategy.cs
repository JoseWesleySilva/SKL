using SKL.Models;
using SKL.Util;

namespace SKL.Strategy.StrategyImpl
{
    public abstract class AbstractStrategy : IStrategy
    {
        public AbstractStrategy()
        {
            Resultado = new Resultado();
        } 

        protected Resultado Resultado { get; set; }

        public abstract Resultado ValidaEntidade(Entidade entidade);
    }
}
