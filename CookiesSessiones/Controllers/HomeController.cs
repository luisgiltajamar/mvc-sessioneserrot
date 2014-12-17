using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CookiesSessiones.Utilidades;

namespace CookiesSessiones.Controllers
{
    [HandleError(View = "Errores")]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Session["falla"].ToString().ToUpper();
            if (Session["color"] != null)
                return RedirectToAction("Ver");
           
            
            throw new MiExcepcion("Color no definido");
            return null;

            //Session.Clear();
            //Session.Abandon();
            //Session.Remove("color");

            // return View();
        }
        [HttpPost]
        public ActionResult Index(String color)
        {
            

            Session["color"] = color;
            return RedirectToAction("Ver");
        }

        public ActionResult Ver()
        {
            return View();
        }
        public ActionResult CrearCookie()
        {
            var coc=new HttpCookie("color","green");
            coc.Expires = DateTime.Now.AddDays(365);
            Response.SetCookie(coc);

            foreach (var coo in Request.Cookies)
            {
                
            }

            return View();
        }
    }
}