using System;

namespace CoreEscuela.Entidades
{
    // Hereda
    public class Alumno: ObjetoEscuelaBase
    {
        public List<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();

    }
}
