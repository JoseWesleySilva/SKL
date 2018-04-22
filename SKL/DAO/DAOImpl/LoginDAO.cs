using System;
using System.Linq;
using SKL.Models;
using SKL.Util;
using Microsoft.EntityFrameworkCore;

namespace SKL.DAO
{
    public class LoginDAO : AbstractDAO
    {
        private Login login;

        public LoginDAO(SkldbMainContext context) 
            : base(context)
        { }
        
        public override Resultado Alterar(Entidade entidade)
        {
            try
            {
                Context.Login.Add((Login)entidade);
                Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Resultado.MensagemErro.Append(e);
            }

            return Resultado;
        }

        public override Resultado Consultar(Entidade entidade)
        {
            try
            {
                login = (Login)entidade;

                var usuarioLogado = Context.Login
                    .Where(l => l.NomeUsuario == login.NomeUsuario && l.Senha == login.Senha)
                    .Include(l => l.Permissao)
                    .FirstOrDefault();

                Resultado.ListaResultados.Add(usuarioLogado);
            }
            catch(Exception e)
            {
                Resultado.MensagemErro.Append(e);
            }
            return Resultado;
        }

        public override Resultado Deletar(Entidade entidade)
        {
            try
            {
                Context.Login.Remove((Login)entidade);
                Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Resultado.MensagemErro.Append(e);
            }
            return Resultado;
        }

        public override Resultado Salvar(Entidade entidade)
        {
            try
            {
                Context.Login.Add((Login)entidade);
                Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Resultado.MensagemErro.Append(e);
            }
            return Resultado;
        }
    }
}
