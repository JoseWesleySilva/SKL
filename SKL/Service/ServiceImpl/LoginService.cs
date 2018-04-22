using SKL.DAO;
using SKL.Models;
using SKL.Util;

namespace SKL.Service
{
    public class LoginService : AbstractService
    {
        private SkldbMainContext Context { get; set; }
        private Login Login { get; set; }
        private readonly LoginDAO _loginDAO;

        public LoginService(SkldbMainContext context)
        {
            Context = context;
            _loginDAO = new LoginDAO(context);
        }
        
        public override Resultado Alterar(Entidade entidade)
        {
            Login = (Login)entidade;
            Resultado = _loginDAO.Alterar(entidade);
            if (Resultado.MensagemErro.Length == 0)
                Resultado.MensagemSucesso.Append($"Usuário {Login.NomeUsuario} alterado com sucesso.");

            return Resultado;
        }

        public override Resultado Consultar(Entidade entidade)
        {
            Login = (Login)entidade;
            Resultado = _loginDAO.Consultar(entidade);
            if (Resultado.MensagemErro.Length == 0 && Resultado.ListaResultados[0] == null)
                Resultado.MensagemErro.Append($"Usuário {Login.NomeUsuario} não encontrado.");
            else
                Resultado.MensagemSucesso.Append($"A consulta retornou {Resultado.ListaResultados.Count}");

            return Resultado;
        }

        public override Resultado Deletar(Entidade entidade)
        {
            Login = (Login)entidade;
            Resultado = _loginDAO.Deletar(entidade);
            if (Resultado.MensagemErro.Length == 0)
                Resultado.MensagemSucesso.Append($"Usuário {Login.NomeUsuario} removido com sucesso.");

            return Resultado;
        }

        public override Resultado Salvar(Entidade entidade)
        {
            Login = (Login)entidade;
            Resultado = _loginDAO.Salvar(entidade);
            if (Resultado.MensagemErro.Length == 0)
                Resultado.MensagemSucesso.Append($"Usuário {Login.NomeUsuario} salvo com sucesso.");

            return Resultado;
        }
    }
}
