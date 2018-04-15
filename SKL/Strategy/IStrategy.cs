using SKL.Util;
using SKL.Models;

namespace SKL.Strategy
{
    public interface IStrategy
    {
        Resultado Resultado { get; set; }
        Resultado ValidaEntidade(Entidade entidade);
    }
}
