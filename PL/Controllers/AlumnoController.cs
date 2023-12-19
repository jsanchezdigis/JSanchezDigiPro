using ML;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoController : Controller
    {
        [HttpGet]
        public ActionResult Form(int? IdAlumno)
        {
            Alumno alumno = new Alumno();
            if (IdAlumno == null)
            {
                return View(alumno);
            }
            else
            {
                AlumnoService.AlumnoServiceClient alumnoClient = new AlumnoService.AlumnoServiceClient();
                Result result = alumnoClient.GetById(IdAlumno.Value);

                if (result.Correct)
                {
                    alumno = (Alumno)result.Object;
                    return View(alumno);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar la informacion";
                    return View("Modal");
                }
            }
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            AlumnoService.AlumnoServiceClient alumnoService = new AlumnoService.AlumnoServiceClient();
            ML.Alumno alumno = new ML.Alumno();
            Result result = alumnoService.GetAll();

            if (result.Correct)
            {
                alumno.Alumnos = result.Objects;
                return View(alumno);
            }
            else
            {
                return View(alumno);
            }
        }

        [HttpPost]
        public ActionResult Form(Alumno alumno)
        {
            AlumnoService.AlumnoServiceClient alumnoClient = new AlumnoService.AlumnoServiceClient();

            if (alumno.IdAlumno == 0)
            {
                Result result = alumnoClient.Add(alumno);

                if (result.Correct)
                {
                    ViewBag.Message = "Se completo el registro satisfactoriamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al insertar el registro";
                }
                return View("Modal");
            }
            else
            {
                Result result = alumnoClient.Update(alumno);
                if (result.Correct)
                {
                    ViewBag.Message = "Se actualizo el registro satisfactoriamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al actualizar el registro";
                }
                return View("Modal");
            }
        }

        [HttpGet]
        public ActionResult Delete(Alumno alumno)
        {
            AlumnoService.AlumnoServiceClient alumnoClient = new AlumnoService.AlumnoServiceClient();
            ML.Result result = alumnoClient.Delete(alumno);
            if (result.Correct)
            {
                ViewBag.Message = "Se elimino el registro satisfactoriamente";
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al eliminar el registro";
            }
            return View("Modal");
        }
    }
}