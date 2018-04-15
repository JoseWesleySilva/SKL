using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SKL.DAO;
using SKL.Models;
using SKL.Service;
using SKL.Fachada;
using SKL.Util;
using Microsoft.AspNetCore.Authorization;

namespace SKL.Controllers
{
    public class LoginController : Controller
    {
        private readonly IFacade _fachada;
        private Resultado Resultado { get; set; }

        public LoginController(SkldbMainContext context)
        {
            _fachada = new Facade(context);
        }

        [HttpGet]
        public IActionResult Logon()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logon(Login login)
        {
            if (!ModelState.IsValid)
                return View();
            else
            {
                Resultado = _fachada.Consultar(login);

                if (string.IsNullOrWhiteSpace(Resultado.MensagemSucesso.ToString()))
                {
                    ViewData["Mensagem"] = Resultado.MensagemSucesso;
                    return RedirectToAction(nameof(Logon), nameof(LoginController));
                }
                else
                {
                    var identity = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name, login.IdLogin.ToString()),
                    //new Claim(ClaimTypes.Role, "ADMIN"),
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return View();
                }
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Loguot()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController));
        }

        [HttpPost]
        private Login ValidarLogon(Login login)
        {
            Resultado = _fachada.Consultar(login);
            return (Login)Resultado.ListaResultados.Single();
        }

        public IActionResult ErroUsuarioNaoLogado() => View();
    }
}
