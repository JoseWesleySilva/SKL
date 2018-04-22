using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SKL.Facade;
using SKL.Models;
using SKL.Util;

namespace SKL.Controllers
{
    public class CursoController : Controller
    {
        private readonly IFacade _fachada;
        private Resultado Resultado { get; set; }

        public CursoController(SkldbMainContext context)
        {
            _fachada = new FacadeImpl(context);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Curso()
        {
            return View();
        }
    }
}