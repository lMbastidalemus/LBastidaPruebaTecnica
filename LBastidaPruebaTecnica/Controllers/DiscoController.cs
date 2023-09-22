using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LBastidaPruebaTecnica.Controllers
{
    public class DiscoController : Controller
    {
        [HttpGet]// GET: Disco
        public ActionResult GetAll()
        {
            ML.Disco disco = new ML.Disco();
            ML.Result result = BL.Disco.GetAll();
            disco.Discos = result.Objetcs;
            return View(disco);
        }

        [HttpGet]
        public ActionResult Form()
        {
            ML.Disco disco = new ML.Disco();
            return View(disco);
        }

        [HttpPost]
        public ActionResult Form(ML.Disco disco)
        {
            ML.Result result = BL.Disco.Add(disco);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Disco Eliminado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "Error al eliminar disco ";
            }
            return PartialView("Modal");

        }
        public ActionResult Delete(int IdDisco)
        {
            ML.Result result = BL.Disco.Delete(IdDisco);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Disco Eliminado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "Error al eliminar disco ";
            }
            return PartialView("Modal");
        }

       
    }
}