using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using angularjs.Application.ApplicationInterfaces;
using angularjs.Application.Factory;
using angularjs.Business.Business;
using Newtonsoft.Json;
using System.Text;

namespace AngularJS.Web.Controllers
{
    public class PratoController : Controller
    {

        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            Formatting = Newtonsoft.Json.Formatting.Indented,
            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        };

        private IPratoApplication _PratoApplication = ApplicationFactory.getInstance().getPratoApplication();
        public ActionResult Index(int id)
        {
            ViewBag.IdRestaurante = id;
            return View();
        }

        public JsonResult Listar(int idRestaurante)
        {
            return Retornar(idRestaurante);
        }

        public JsonResult Excluir(Prato prato)
        {
            try
            {
                var retorno = _PratoApplication.Delete(prato);
                return Retornar(prato.IdRestaurante);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult Incluir(Prato prato)
        {
            try
            {
                _PratoApplication.Save(prato);
                _PratoApplication.SaveChanges();
                return Retornar(prato.IdRestaurante);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private JsonResult Retornar(int idRestaurante)
        {
            var pratos = _PratoApplication.Find(x => x.IdRestaurante == idRestaurante);
            var content = JsonConvert.SerializeObject(pratos, Settings);
            return Json(content, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

    }
}