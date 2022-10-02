using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Curso: ObjetoEscuelaBase, ILugar
    {
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();
        public List<Alumno> Alumnos { get; set; } = new List<Alumno>();

        /// <summary>
        /// Forma explicita de una interface
        /// </summary>
        //string ILugar.Direccion { get; set; }
        //public void ILugar.LimpiarLugar()
        //{
        //    Printer.DrawLine();
        //    Console.WriteLine("Limpiando Establecimiento....");
        //    Console.WriteLine($"Curso {Nombre} esta limpio");
        //}

        /// <summary>
        /// Forma implicita de una interface
        /// </summary>
        public string Direccion { get; set; } // Propiedad de interfaz

        public void LimpiarLugar() // Método de interfaz
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando Establecimiento....");
            Console.WriteLine($"Curso {Nombre} esta limpio");
        }
    }
}
