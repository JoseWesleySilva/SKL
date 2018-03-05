using SKL.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SKL.Models;

namespace SKL.DAO
{
    public interface IDAO
    {
        Resultado Consultar(Entidade entidade);
        Resultado Deletar(Entidade entidade);
        Resultado Salvar(Entidade entidade);
        Resultado Alterar(Entidade entidade);
    }
}
