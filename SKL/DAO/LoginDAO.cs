using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SKL.Models;
using SKL.Util;

namespace SKL.DAO
{
    public class LoginDAO : AbstractDAO
    {
        public LoginDAO(SkldbMainContext context)
            : base(context)
        { }

        public override Resultado Salvar(Entidade entidade)
        {
            _context.Login.Add((Login)entidade);
            _context.SaveChangesAsync();
            Resultado.Mensagem = "Login cadastrado com sucesso.";
            return Resultado;
        }

        public override Resultado Alterar(Entidade entidade)
        {
            _context.Login.Add((Login)entidade);
            _context.SaveChangesAsync();
            Resultado.Mensagem = "Login atualizado com sucesso.";
            return Resultado;
        }

        public override Resultado Consultar(Entidade entidade)
        {
            var login = (Login)entidade;

            var usuarioLogado = (from l in _context.Login select l)
                .Single(l => l.IdLogin == login.IdLogin);

            Resultado.ListaResultados.Add(usuarioLogado);

            return Resultado;
        }

        public override Resultado Deletar(Entidade entidade)
        {
            var Login = (Login)entidade;
            _context.Login.Remove(Login);

            Resultado.Mensagem = ("Usuário removido com sucesso.");
            return Resultado;
        }
    }
}
