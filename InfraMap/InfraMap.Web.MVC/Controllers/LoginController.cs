using System.Web.Mvc;
using InfraMap.Web.MVC.Helpers;
using InfraMap.Web.MVC.Models;
using InfraMap.Web.MVC.Seguranca;

namespace InfraMap.Web.MVC.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var servicoAutenticacao = Factory.CriarServicoAutenticacao();

                var usuarioAutenticado = servicoAutenticacao.BuscarPorAutenticacao(loginModel.Login, loginModel.Senha);

                if (usuarioAutenticado != null)
                {
                    ControleDeSessao.CriarSessaoDeUsuario(new UsuarioLogado(usuarioAutenticado));
                    return RedirectToAction("Index", "Sede");
                }
            }

            ViewBag.Erro = "Usuário ou senha inválidos.";
            ModelState.AddModelError("INVALID_LOGIN", "Usuário ou senha inválidos.");
            return View("Index", loginModel);
        }

        public ActionResult Sair()
        {
            ControleDeSessao.Encerrar();
            return RedirectToAction("Index", "Login");
        }
    }
}