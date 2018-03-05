using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SKL.DAO;
using SKL.Models;
using SKL.Service;

namespace SKL.Controllers
{
    public class LoginController : Controller
    {
        private readonly SkldbMainContext _context;
        private readonly LoginService _loginService;

        public LoginController(SkldbMainContext context)
        {
            _context = context;
            _loginService = new LoginService(context);
        }

        /*  localhost/Login/Logon
        *   metodo inicial de login
        */
        [HttpGet]
        public IActionResult Logon()
        {
            return View();
        }

        /*  localhost/Login/Logon
         *  metodo de validação de logon do usuário
         */
        [HttpPost]
        public async Task<IActionResult> Logon(Login login)
        {
            var resultado = _loginService.ConsultarLogin(login);

            if (string.IsNullOrWhiteSpace(resultado.Mensagem))
            {
                ViewData["Mensagem"] = resultado.Mensagem;
                return RedirectToAction(nameof(Logon), nameof(LoginController));
            }
            else
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, login.IdLogin.ToString()),
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, principal);
            
                return View();
            }
        }

        /*  localhost/Login/Logout
         *  remover usuário logado
         */
        [HttpGet]
        public async Task<IActionResult> Loguot()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController));
        }

        /* 
         *  metodo para validação de usuario em base de dados
         */
        [HttpPost]
        private Login ValidarLogon(Login login)
        {
            var log = new Login();
            return login;
        }

        public IActionResult ErroUsuarioNaoLogado() => View();
    }
}
