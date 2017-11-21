using System.Web.Mvc;

namespace CZE.Web.Areas.AdministrativniRadnik
{
    public class AdministrativniRadnikAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdministrativniRadnik";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdministrativniRadnik_default",
                "AdministrativniRadnik/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}