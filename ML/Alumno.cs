using System.Collections.Generic;

namespace ML
{
    public class Alumno
    {
        public int IdAlumno { get; set; }

        public string Nombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public List<object> Alumnos { get; set; }
    }
}
