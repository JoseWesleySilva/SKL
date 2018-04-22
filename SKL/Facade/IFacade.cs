using SKL.Models;
using SKL.Util;

namespace SKL.Facade
{
    public interface IFacade
    {
        Resultado Alterar(Entidade entidade);
        Resultado Consultar(Entidade entidade);
        Resultado Deletar(Entidade entidade);
        Resultado Salvar(Entidade entidade);
    }
}
