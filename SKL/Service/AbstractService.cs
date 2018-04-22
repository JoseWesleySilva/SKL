using SKL.Models;
using SKL.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKL.Service
{
    public abstract class AbstractService : IService
    {
        public AbstractService()
        {
            Resultado = new Resultado();        
        }

        protected Resultado Resultado { get; set; }

        public abstract Resultado Alterar(Entidade entidade);
        public abstract Resultado Consultar(Entidade entidade);
        public abstract Resultado Deletar(Entidade entidade);
        public abstract Resultado Salvar(Entidade entidade);
    }
}
