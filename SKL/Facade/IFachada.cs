using SKL.Models;
using SKL.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKL.Facade
{
    interface IFachada
    {
        Resultado Salvar(Entidade entidades);
        Resultado Deletar(Entidade entidades);
        Resultado Alterar(Entidade entidade);
        Resultado Consultar(Entidade entidade);
    }
}
