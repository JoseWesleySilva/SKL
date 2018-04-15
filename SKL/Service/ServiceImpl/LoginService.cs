using SKL.DAO;
using SKL.Models;
using SKL.Util;

namespace SKL.Service
{
    public class LoginService : IService
    {
        private SkldbMainContext Context { get; set; }
        private Login Login { get; set; }
        private readonly LoginDAO _loginDAO;

        public LoginService(SkldbMainContext context)
        {
            Context = context;
            _loginDAO = new LoginDAO(context);
        }

        public Resultado Resultado
        {
            get { return Resultado; }
            set { Resultado = value; }
        }

        public Resultado Alterar(Entidade entidade)
        {
            Login = (Login)entidade;
            Resultado =_loginDAO.Alterar(entidade);
            if (Resultado.MensagemErro.Length == 0)
                Resultado.MensagemSucesso.Append($"Usuário {Login.NomeUsuario} alterado com sucesso.");

            return Resultado;
        }

        public Resultado Consultar(Entidade entidade)
        {
            Login = (Login)entidade;
            Resultado = _loginDAO.Consultar(entidade);
            if (Resultado.MensagemErro.Length == 0 && Resultado.ListaResultados.Count == 0)
                Resultado.MensagemErro.Append($"Usuário {Login.NomeUsuario} não encontrado.");
            else
                Resultado.MensagemSucesso.Append($"A consulta retornou {Resultado.ListaResultados.Count}");

            return Resultado;
        }

        public Resultado Deletar(Entidade entidade)
        {
            Login = (Login)entidade;
            Resultado = _loginDAO.Deletar(entidade);
            if (Resultado.MensagemErro.Length == 0)
                Resultado.MensagemSucesso.Append($"Usuário {Login.NomeUsuario} removido com sucesso.");

            return Resultado;
        }

        public Resultado Salvar(Entidade entidade)
        {
            Login = (Login)entidade;
            Resultado = _loginDAO.Salvar(entidade);
            if (Resultado.MensagemErro.Length == 0)
                Resultado.MensagemSucesso.Append($"Usuário {Login.NomeUsuario} salvo com sucesso.");

            return Resultado;
        }
    }
}
