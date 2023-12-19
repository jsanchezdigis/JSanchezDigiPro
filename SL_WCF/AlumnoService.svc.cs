using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AlumnoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AlumnoService.svc or AlumnoService.svc.cs at the Solution Explorer and start debugging.
    public class AlumnoService : IAlumnoService
    {
        public Result Add(ML.Alumno alumno)
        {
            Result result = BL.Alumno.Add(alumno);

            if (result.Correct)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public Result Update(ML.Alumno alumno)
        {
            Result result = BL.Alumno.Update(alumno);

            if (result.Correct)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public Result Delete(ML.Alumno alumno)
        {
            Result result = BL.Alumno.Delete(alumno);

            if (result.Correct)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public Result GetById(int IdAlumno)
        {
            Result result = BL.Alumno.GetById(IdAlumno);

            if (result.Correct)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public Result GetAll()
        {
            Result result = BL.Alumno.GetAll();

            if (result.Correct)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
