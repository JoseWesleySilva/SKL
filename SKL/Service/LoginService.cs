using SKL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SKL.Models;
using SKL.Util;

namespace SKL.Service
{
    public class LoginService
    {
        private readonly LoginDAO _loginDAO;
        private readonly SkldbMainContext _context;

        public LoginService(SkldbMainContext context)
        {
            _context = context;
            _loginDAO = new LoginDAO(context);
        }

        public Resultado ConsultarLogin(Login login)
        {
            var resultado = _loginDAO.Consultar(login);

            if (resultado.ListaResultados.Count == 0)
                resultado.Mensagem = "Nunhum usuário encontrado.";

            return resultado;
        }
    }
}
