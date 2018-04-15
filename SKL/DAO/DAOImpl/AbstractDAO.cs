using SKL.Models;
using SKL.Util;

namespace SKL.DAO
{
    public abstract class AbstractDAO : IDAO
    {
        protected SkldbMainContext Context { get; set; }
        protected Resultado Resultado { get; set; }

        public AbstractDAO(SkldbMainContext context)
        {
            Context = context;
        }

        public abstract Resultado Alterar(Entidade entidade);
        public abstract Resultado Consultar(Entidade entidade);
        public abstract Resultado Deletar(Entidade entidade);
        public abstract Resultado Salvar(Entidade entidade);
    }
}
