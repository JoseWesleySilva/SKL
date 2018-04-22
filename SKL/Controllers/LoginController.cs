using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SKL.Models;
using SKL.Util;
using Microsoft.AspNetCore.Authorization;
using SKL.Facade;

namespace SKL.Controllers
{
    public class LoginController : Controller
    {
        private readonly IFacade _fachada;
        private Resultado Resultado { get; set; }

        public LoginController(SkldbMainContext context)
        {
            _fachada = new Facade.FacadeImpl(context);
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

                if (!string.IsNullOrWhiteSpace(Resultado.MensagemErro.ToString()))
                {
                    ViewData["Mensagem"] = Resultado.MensagemErro;
                    return View();
                }
                else
                { // cria cookie de validação de dados
                    Login l = (Login)Resultado.ListaResultados.First();
                    var identity = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, l.IdLogin.ToString()),
                        new Claim(ClaimTypes.Role, l.Permissao.Descricao),
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction(nameof(CursoController.Curso), nameof(Curso));
                }
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult ErroUsuarioNaoLogado() => View();
    }
}
