using SKL.Util;
using SKL.Models;

namespace SKL.Strategy
{
    public interface IStrategy
    {
        Resultado ValidaEntidade(Entidade entidade);
    }
}
