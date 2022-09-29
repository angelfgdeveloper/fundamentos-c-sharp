using CoreEscuela.Entidades;

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

            Curso[] arregloCursos = new Curso[3];

            arregloCursos[0] = new Curso()
            {
                Nombre = "Curso de fundamentos C#",
            };

            Curso curso2 = new Curso()
            {
                Nombre = "Curso Intermedio C#",
                // UniqueId = "c" => No lo podemos utilizar ya que lo encapsulamos
            };

            arregloCursos[1] = curso2;

            arregloCursos[2] = new Curso()
            {
                Nombre = "Curso Avanzado C#",
                // UniqueId = "c" => No lo podemos utilizar ya que lo encapsulamos
            };

            Console.WriteLine(escuela);
            Console.WriteLine("==================");
            // cw + tab => abre el log
            //Console.WriteLine(curso1.Nombre + ", " + curso1.UniqueId);
            //Console.WriteLine($"{curso2.Nombre}, {curso2.UniqueId}");
            //Console.WriteLine(curso3);

            // IMPRIMIR ARREGLOS
            //Console.WriteLine(arregloCursos[0].Nombre);
            //Console.WriteLine("Presione ENTER para continuar");
            //Console.ReadLine(); // Espera a que presione enter
            //Console.WriteLine(arregloCursos[5].Nombre); // Truena porque no existe ese elemento

            ImprimirCursosWhile(arregloCursos);

            Console.WriteLine("==================");
            ImprimirCursosDoWhile(arregloCursos);

            Console.WriteLine("==================");
            ImprimirCursosFor(arregloCursos);

            Console.WriteLine("==================");
            ImprimirCursosForEach(arregloCursos);

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
