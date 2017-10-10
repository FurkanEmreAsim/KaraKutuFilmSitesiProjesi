using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramlama.Models;

namespace WebProgramlama.Controllers
{
    public class FilmController : Controller
    {
        ImdbEntities ent = new ImdbEntities();   
        
        public ActionResult Index()
        {
            AnaSayfaDTO obj = new AnaSayfaDTO();
            obj.film = ent.Film.Where(x => x.FilmID > 0).ToList();       
            return View(obj);
        }

       
    }
}