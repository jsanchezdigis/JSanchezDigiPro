using System.Collections.Generic;

namespace ML
{
    public class AlumnoMateria
    {
        public int IdAlumnoMateria { get; set; }

        public Alumno Alumno { get; set; }

        public Materia Materia { get; set; }

        public List<object> AlumnoMaterias { get; set; }
    }
}
