using CoreEscuela.Entidades;
using static System.Console; // Obviamos el Console

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            Escuela school = new Escuela("Platzi Academy", 2012);
            school.Pais = "Colombia";
            school.Ciudad = "Bogota";

            //Uso de enum =>
            school.TipoEscuela = TiposEscuela.Primaria;

            // Parametros opcionales y seleccion de argumento por pais:"bla bla"
            Escuela escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria, pais: "Colombia", ciudad: "Bogota");

            // #1 Arreglos ========================================
            //Curso curso1 = new Curso()
            //{
            //    Nombre = "Curso de fundamentos C#",
            //    // UniqueId = "c" => No lo podemos utilizar ya que lo encapsulamos
            //};
            //Curso curso2 = new Curso()
            //{
            //    Nombre = "Curso Intermedio C#",
            //    // UniqueId = "c" => No lo podemos utilizar ya que lo encapsulamos
            //};
            //Curso curso3 = new Curso()
            //{
            //    Nombre = "Curso Avanzado C#",
            //    // UniqueId = "c" => No lo podemos utilizar ya que lo encapsulamos
            //};

            // #2 Arreglos ===========================================
            //Curso[] arregloCursos = new Curso[3];
            //arregloCursos[0] = new Curso()
            //{
            //    Nombre = "Curso de fundamentos C#",
            //};
            //Curso curso2 = new Curso()
            //{
            //    Nombre = "Curso Intermedio C#",
            //    // UniqueId = "c" => No lo podemos utilizar ya que lo encapsulamos
            //};
            //arregloCursos[1] = curso2;
            //arregloCursos[2] = new Curso()
            //{
            //    Nombre = "Curso Avanzado C#",
            //    // UniqueId = "c" => No lo podemos utilizar ya que lo encapsulamos
            //};

            // #3 Arreglos =============================================
            //Curso[] arregloCursos = new Curso[3]
            //{
            //    new Curso() { Nombre = "Curso de fundamentos C#" },
            //    new Curso() { Nombre = "Curso Intermedio C#" },
            //    new Curso() { Nombre = "Curso Avanzado C#" }
            //};

            // #4 Arreglos =============================================
            //Curso[] arregloCursos = {
            //    new Curso() { Nombre = "Curso de fundamentos C#" },
            //    new Curso() { Nombre = "Curso Intermedio C#" },
            //    new Curso() { Nombre = "Curso Avanzado C#" }
            //};
            //escuela.Cursos = arregloCursos; // asignarlo al metodo

            // #5 Arreglos =============================================
            escuela.Cursos = new Curso[] {
                new Curso() { Nombre = "Curso de fundamentos C#" },
                new Curso() { Nombre = "Curso Intermedio C#" },
                new Curso() { Nombre = "Curso Avanzado C#" }
            };

            Console.WriteLine(escuela);
            Console.WriteLine("====================");
            // cw + tab => abre el log
            //Console.WriteLine(curso1.Nombre + ", " + curso1.UniqueId);
            //Console.WriteLine($"{curso2.Nombre}, {curso2.UniqueId}");
            //Console.WriteLine(curso3);

            // IMPRIMIR ARREGLOS
            //Console.WriteLine(arregloCursos[0].Nombre);
            //Console.WriteLine("Presione ENTER para continuar");
            //Console.ReadLine(); // Espera a que presione enter
            //Console.WriteLine(arregloCursos[5].Nombre); // Truena porque no existe ese elemento

            //ImprimirCursosWhile(arregloCursos);
            //Console.WriteLine("==================");
            //ImprimirCursosDoWhile(arregloCursos);
            //Console.WriteLine("==================");
            //ImprimirCursosFor(arregloCursos);
            //Console.WriteLine("==================");
            //ImprimirCursosForEach(arregloCursos);

            // Fallas
            //escuela.Cursos = null;
            //escuela.Cursos = new Curso[0];
            //escuela = null;
            ImprimirCursosEscuela(escuela);

        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            // Reducimos el Console con el usigin
            WriteLine("====================");
            WriteLine("Cursos de la Escuela");
            WriteLine("====================");

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

        private static void ImprimirCursosWhile(Curso[] arregloCursos)
        {
            int contador = 0;
            while (contador < arregloCursos.Length)
            {
                Console.WriteLine($"Nombre: {arregloCursos[contador].Nombre}, ID: {arregloCursos[contador].UniqueId}");
                // contador = contador + 1;
                // contador += 1;
                contador++;
            }
        }

        private static void ImprimirCursosDoWhile(Curso[] arregloCursos)
        {
            // Entra la primera vez
            int contador = 0;
            do
            {
                Console.WriteLine($"Nombre: {arregloCursos[contador].Nombre}, ID: {arregloCursos[contador].UniqueId}");
                contador++;
            } while (contador < arregloCursos.Length);
        }

        private static void ImprimirCursosFor(Curso[] arregloCursos)
        {
            for (int i = 0; i < arregloCursos.Length; i++)
            {
                Console.WriteLine($"Nombre: {arregloCursos[i].Nombre}, ID: {arregloCursos[i].UniqueId}");

            }
        }

        private static void ImprimirCursosForEach(Curso[] arregloCursos)
        {
            foreach (Curso curso in arregloCursos)
            {
                Console.WriteLine($"Nombre: {curso.Nombre}, ID: {curso.UniqueId}");
            }
        }
    }
}
