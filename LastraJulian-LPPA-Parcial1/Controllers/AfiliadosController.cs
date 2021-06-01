using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LastraJulian_LPPA_Parcial1.Models;
using LastraJulian_LPPA_Parcial1.Services;

namespace LastraJulian_LPPA_Parcial1.Controllers
{
    public class AfiliadosController : Controller
    {
        public ActionResult Afiliados()
        {
            var model = Listar();
            return View(model);
        }

        #region DataBase Controller >> Pasar a un controlador aparte
        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            var model = Buscar(id);
            return RedirectToAction("Afiliados");
        }
        public ActionResult Crear(Afiliados model)
        {
            Agregar(model);
            return RedirectToAction("Afiliados");
        }
        public ActionResult Editar(int id)
        {
            var model = Buscar(id);
            return View(model);
        }
        public Afiliados Buscar(int id)
        {
            var db = new BaseDataService<Afiliados>();
            return db.GetById(id);
        }

        //Acordate de sacar los metodos de aca!!
        public void Agregar(Afiliados model)
        {
            var db = new BaseDataService<Afiliados>();
            db.Create(model);
        }
        public void Eliminar(Afiliados model)
        {
            var db = new BaseDataService<Afiliados>();
            db.Delete(model);
            RedirectToAction("Afiliados");
        }

        public List<Afiliados> Listar()
        {
            var db = new BaseDataService<Afiliados>();
            var lista = db.Get();
            return lista;
        }
        #endregion
    }
}