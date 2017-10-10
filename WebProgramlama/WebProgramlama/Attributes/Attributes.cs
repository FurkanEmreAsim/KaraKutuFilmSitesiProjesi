using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramlama.Models;

namespace WebProgramlama.Attributes
{
    public class AdminRoleControl : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // action çalışmadan önce yapılacak işlemler

            var ent = new ImdbEntities();
            if (HttpContext.Current.Session["eposta"] == null)
            {
                filterContext.HttpContext.Response.Redirect("~/Home/Register");
            }
            else
            {
                string Eposta = HttpContext.Current.Session["eposta"].ToString();
                var uye_rol = ent.Uyelik.FirstOrDefault(x => x.Email == Eposta).Role;
                if (uye_rol != "Admin")
                {
                    filterContext.HttpContext.Response.Redirect("~/Film/Index");
                }
            }
            base.OnActionExecuting(filterContext);
        }

    }
}