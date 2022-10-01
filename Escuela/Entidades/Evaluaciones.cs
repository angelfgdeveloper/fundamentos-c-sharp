using System;

namespace CoreEscuela.Entidades
{
    public class Evaluaciones
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }
        public Alumno Alumno { get; set; }
        public Asignatura Asignatura { get; set; }
        public double Nota { get; set; }

        // Contructor corto =>
        public Evaluaciones() => UniqueId = Guid.NewGuid().ToString(); // Genera un string aleatorio para el ID
    }
}
