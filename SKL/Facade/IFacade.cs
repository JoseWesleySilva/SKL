using SKL.Models;
using SKL.Util;

namespace SKL.Fachada
{
    public interface IFacade
    {
        Resultado Resultado { get; set; }

        Resultado Alterar(Entidade entidade);
        Resultado Consultar(Entidade entidade);
        Resultado Deletar(Entidade entidade);
        Resultado Salvar(Entidade entidade);
    }
}
