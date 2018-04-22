using SKL.Models;
using SKL.Util;

namespace SKL.Service
{
    public interface IService
    {
        Resultado Alterar(Entidade entidade);
        Resultado Consultar(Entidade entidade);
        Resultado Deletar(Entidade entidade);
        Resultado Salvar(Entidade entidade);
    }
}
