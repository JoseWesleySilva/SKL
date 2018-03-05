using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SKL.Models;
using SKL.Util;

namespace SKL.DAO
{
    public abstract class AbstractDAO : IDAO
    {
        protected readonly SkldbMainContext _context;
        protected Resultado Resultado { get; set; }

        public AbstractDAO(SkldbMainContext context)
        {
            _context = context;
        }

        public abstract Resultado Salvar(Entidade entidade);
        public abstract Resultado Alterar(Entidade entidade);
        public abstract Resultado Consultar(Entidade entidade);
        public abstract Resultado Deletar(Entidade entidade);
    }
}
