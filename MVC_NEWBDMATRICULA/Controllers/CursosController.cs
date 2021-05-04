using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVC_NEWBDMATRICULA.Models;

namespace MVC_NEWBDMATRICULA.Controllers
{
    public class CursosController : Controller
    {
        // variables del DAO a utilizar
        Cursos_DAO cur_dao = new Cursos_DAO();
        Especialidad_DAO esp_dao = new Especialidad_DAO();

        List<string> carreras = new List<string>() { "Computacion","Administracion",
            "Contabilidad","Diseño" };

        // GET: Cursos
        public ActionResult CursosEspecialidad(string codigo="", string xcarrera="")
        {
            var listado = cur_dao.CursosPorEspecialidad(codigo);
            //
            ViewBag.CARRERAS = new SelectList(carreras);   
            //
            ViewBag.ESPECIALIDADES = new SelectList(
                esp_dao.Especialidades(), // data a enviar de tipo coleccion
                "codesp",  // nombre de columna PK
                "nomesp"  // nombre de columna a Mostrarse
                );
            //
            return View(listado);
        }

        public ActionResult CursosCosto(decimal ncosto=0,
                                        string nombre="",
                                        int edad=0)
        {
            var listado = cur_dao.CursosPorCosto(1000);
            //
            if (nombre == "alumno" && edad >= 18)
            {
                listado = cur_dao.CursosPorCosto(ncosto);
            }

            ViewBag.COSTO = ncosto;
            ViewBag.NOMBRE = nombre;
            ViewBag.EDAD = edad;

            return View(listado);
        }

        public ActionResult GrabarCurso()
        {

            Cursos obj = new Cursos();
            return View(obj);

        }
        [HttpPost]
        public ActionResult GrabarCurso(Cursos obj)
        {

            if(ModelState.IsValid == true)
            {

                ViewBag.MENSAJE = cur_dao.RegistrarCurso(obj);

            }
            return View();

        }

    }
}