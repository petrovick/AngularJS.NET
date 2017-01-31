using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using angularjs.Business;

namespace angularjs.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetProdutos()
        {
            var usuarios = new List<Usuario>();
            usuarios.Add(new Usuario(){ IdUsuario = 1, 
                Facebook = true, 
                Nome = "Gabriel Petrovick", 
                RedeSocialId = "redesocialidgabrielPetrovick", 
                Senha = "senhaGabrielPetrovick", 
                Token = "tokenGabrielPetrovick", 
                Username = "usernamegabrielPetrovick"});
            return Json(usuarios, JsonRequestBehavior.AllowGet);
        }
    }
}