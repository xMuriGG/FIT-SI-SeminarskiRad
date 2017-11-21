using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CZE.Data.Models;
using System.Web.Mvc;
namespace CZE.Web.Helper
{
    public class Autorizacija : FilterAttribute, IAuthorizationFilter
    {
        private readonly UlogeKorisnika[] _autorizovatiUloge;
        public Autorizacija(params UlogeKorisnika[] dozvolitiUloge)
        {
            _autorizovatiUloge = dozvolitiUloge;
        }
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            LogiraniKorisnik k = Autentifikacija.GetLogiraniKorisnik(filterContext.HttpContext);

            if (k == null)
            {
                if (!filterContext.HttpContext.Response.IsRequestBeingRedirected)
                    filterContext.HttpContext.Response.Redirect("/Autentifikacija/Index");
                return;
            }

            foreach (UlogeKorisnika uloga in _autorizovatiUloge)
                {
                    if (k.UlogaKorisnika==uloga)
                        return;
                }

            filterContext.HttpContext.Response.Redirect("/Autentifikacija/Index");
        }
    }
}