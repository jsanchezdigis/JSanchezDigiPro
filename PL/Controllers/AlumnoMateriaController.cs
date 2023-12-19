using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        [HttpGet]
        public ActionResult GetAllAlumno()
        {
            ML.Alumno alumno = new ML.Alumno();

            ML.Result result = BL.Alumno.GetAll();

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

        [HttpGet]
        public ActionResult TablaMaterias(int IdAlumno)
        {
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
            alumnoMateria.Alumno = new ML.Alumno();
            alumnoMateria.Alumno.IdAlumno = IdAlumno;
            Session["IdAlumno"] = IdAlumno;

            ML.Result result = BL.AlumnoMateria.GetAll(IdAlumno);
            ML.Result resultAlumno = BL.Alumno.GetById(IdAlumno);

            if (result.Correct)
            {
                alumnoMateria.Alumno = (ML.Alumno)resultAlumno.Object;
                alumnoMateria.Alumno.IdAlumno = IdAlumno;
                alumnoMateria.AlumnoMaterias = result.Objects;
                return View(alumnoMateria);
            }
            else
            {
                return View(alumnoMateria);
            }
        }

        [HttpGet]
        public ActionResult TablaMateriasDisponibles()
        {
            int IdAlumno = (int)(Session["IdAlumno"]);
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
            alumnoMateria.Alumno = new ML.Alumno();
            alumnoMateria.Alumno.IdAlumno = IdAlumno;

            ML.Result result = BL.AlumnoMateria.AlumnoMateriasDisponibles(alumnoMateria.Alumno.IdAlumno);

            if (result.Correct)
            {
                alumnoMateria.AlumnoMaterias = result.Objects;
                return View(alumnoMateria);
            }
            else
            {
                return View(alumnoMateria);
            }
        }

        [HttpPost]
        public ActionResult TablaMateriasDisponibles(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();
            if (alumnoMateria.AlumnoMaterias != null)
            {
                alumnoMateria.Alumno = new ML.Alumno();
                int IdAlumno = (int)(Session["IdAlumno"]);
                alumnoMateria.Alumno.IdAlumno = IdAlumno;
                foreach (string IdMateria in alumnoMateria.AlumnoMaterias)
                {
                    alumnoMateria.Materia = new ML.Materia();
                    alumnoMateria.Materia.IdMateria = int.Parse(IdMateria);
                    result = BL.AlumnoMateria.Add(alumnoMateria);
                }
                result.Correct = true;
                ViewBag.Message = "Se agrego el registro satisfactoriamente";
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al agregar el registro";
            }
            return View("Modal", alumnoMateria);

        }

        [HttpGet]
        public ActionResult Delete(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();
            alumnoMateria.Alumno = new ML.Alumno();
            int IdAlumno = (int)(Session["IdAlumno"]);
            alumnoMateria.Alumno.IdAlumno = IdAlumno;

            result = BL.AlumnoMateria.Delete(alumnoMateria);
            if (result.Correct)
            {
                ViewBag.Message = "Se elimino el registro satisfactoriamente";
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al eliminar el registro";
            }
            return View("Modal", alumnoMateria);
        }
    }
}