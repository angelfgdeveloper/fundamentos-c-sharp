using CoreEscuela.App;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console; // Obviamos el Console

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            EscuelaEngine engine = new EscuelaEngine();
            engine.Inicializar();

            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");
            //Printer.Beep(10000, count: 10);
            ImprimirCursosEscuela(engine.Escuela);
        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            // Reducimos el Console con el usigin
            Printer.WriteTitle("Cursos de la Escuela");

            // Operador logico de corto circuito
            //if (escuela != null && escuela.Cursos != null)
            if (escuela?.Cursos != null) // Verifica que exista la escuela y que no sea null Cursos
            {
                foreach (Curso curso in escuela.Cursos)
                {
                    WriteLine($"Nombre: {curso.Nombre}, ID: {curso.UniqueId}");
                }
            }

        }

    }
}
