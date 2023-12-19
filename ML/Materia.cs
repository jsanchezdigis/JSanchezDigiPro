using System.Collections.Generic;

namespace ML
{
    public class Materia
    {
        public int IdMateria { get; set; }

        public string Nombre { get; set; }

        public decimal Costo { get; set; }

        public List<object> Materias { get; set; }
    }
}
