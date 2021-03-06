﻿using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InfraMap.Web.MVC.Seguranca
{
    public class Autorizador : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            UsuarioLogado usuario = ControleDeSessao.UsuarioLogado;

            if (usuario != null && AuthorizeCore(filterContext.HttpContext))
            {
                GenericIdentity myIdentity = new GenericIdentity(usuario.Login);
                GenericPrincipal principal = new GenericPrincipal(myIdentity, usuario.Permissoes.ToArray());
                Thread.CurrentPrincipal = principal;
                HttpContext.Current.User = principal;
                base.OnAuthorization(filterContext);
            }
            else
            {
                RedirecionarParaLogin(filterContext);
            }
        }

        private void RedirecionarParaLogin(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                                                new RouteValueDictionary
                                                {
                                                    { "action", "Index" },
                                                    { "controller", "Login" }
                                                });
        }
    }
}
