using System;

namespace CoreEscuela.Entidades
{
    public class Alumno
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }

        public List<Evaluaciones> Evaluaciones { get; set; } = new List<Evaluaciones>();

        // Contructor corto =>
        public Alumno() => UniqueId = Guid.NewGuid().ToString(); // Genera un string aleatorio para el ID
    }
}
