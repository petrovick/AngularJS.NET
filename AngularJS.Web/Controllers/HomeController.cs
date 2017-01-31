using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using angularjs.Business;

namespace AngularJS.Web.Controllers
{
    public class HomeController : Controller
    {

        //allmatechEntities entity = new allmatechEntities();
        public ActionResult Index()
        {
            return View();
        }

        //public JsonResult GetProdutos()
        //{
        //    var usuarios = entity.Usuario.ToList();
        //    return Json(usuarios, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult IncluirUsuario(Usuario usuario)
        //{
        //    try
        //    {
        //        entity.Usuario.Add(usuario);
        //        entity.SaveChanges();
        //        var usuarios = entity.Usuario.ToList();
        //        return Json(usuarios, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public JsonResult ExcluirUsuario(Usuario usuario)
        //{
        //    try
        //    {
        //        var entity = new allmatechEntities();
        //        entity.Usuario.Attach(usuario);
        //        entity.Entry(usuario).State = EntityState.Deleted;
        //        entity.SaveChanges();
        //        var produtos = entity.Usuario.ToList();
        //        return Json(produtos, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}