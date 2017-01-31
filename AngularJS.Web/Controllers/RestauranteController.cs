using angularjs.Business.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using angularjs.Application.ApplicationInterfaces;
using angularjs.Application.Factory;
using Newtonsoft.Json;

namespace AngularJS.Web.Controllers
{
    public class RestauranteController : Controller
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            Formatting = Newtonsoft.Json.Formatting.Indented,
            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        };

        private IRestauranteApplication _RestauranteApplication = ApplicationFactory.getInstance().getRestauranteApplication();
        // GET: Restaurante
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Listar()
        {
            //_RestauranteApplication.Save(new Restaurante() {Nome = "testando"});
            //_RestauranteApplication.SaveChanges();
            var restaurantes = _RestauranteApplication.GetAll().ToList();
            var content = JsonConvert.SerializeObject(restaurantes, Settings);
            return Json(content, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Incluir(Restaurante restaurante)
        {
            try
            {
                _RestauranteApplication.Save(restaurante);
                _RestauranteApplication.SaveChanges();
                var restaurantes = _RestauranteApplication.GetAll();
                return Json(restaurantes, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult Excluir(Restaurante restaurante)
        {
            try
            {
                var retorno = _RestauranteApplication.Delete(restaurante);
                var restaurantes = _RestauranteApplication.GetAll();
                return Json(restaurantes, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}