using System;

namespace CoreEscuela.Entidades
{
    public class Asignatura
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }

        // Contructor corto =>
        public Asignatura() => UniqueId = Guid.NewGuid().ToString(); // Genera un string aleatorio para el ID
    }
}
