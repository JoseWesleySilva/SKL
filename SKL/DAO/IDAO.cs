using SKL.Util;
using SKL.Models;

namespace SKL.DAO
{
    public interface IDAO
    {
        Resultado Alterar(Entidade entidade);
        Resultado Consultar(Entidade entidade);
        Resultado Deletar(Entidade entidade);
        Resultado Salvar(Entidade entidade);
    }
}
