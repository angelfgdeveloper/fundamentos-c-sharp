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

            // Arreglos
            usoDeArreglos();

            // #5 Arreglos =============================================
            //escuela.Cursos = new Curso[] {
            //    new Curso() { Nombre = "Curso de fundamentos C#" },
            //    new Curso() { Nombre = "Curso Intermedio C#" },
            //    new Curso() { Nombre = "Curso Avanzado C#" }
            //};
            
            // Listas
            escuela.Cursos = new List<Curso>()
            {
                new Curso() { Nombre = "Curso de fundamentos C#", Jornada = TiposJornada.Maniana },
                new Curso() { Nombre = "Curso Intermedio C#", Jornada = TiposJornada.Maniana },
                new Curso() { Nombre = "Curso Avanzado C#", Jornada = TiposJornada.Maniana }
            };

            escuela.Cursos.Add(new Curso() { Nombre = "Curso de Github & Git", Jornada = TiposJornada.Tarde });
            escuela.Cursos.Add(new Curso() { Nombre = "Curso de GitLab Avanzado", Jornada = TiposJornada.Tarde });

            List<Curso> otraColeccion = new List<Curso>()
            {
                new Curso() { Nombre = "Curso de fundamentos C# 2024", Jornada = TiposJornada.Maniana },
                new Curso() { Nombre = "Curso Intermedio C# 2024", Jornada = TiposJornada.Maniana },
                new Curso() { Nombre = "Curso Avanzado C# 2024", Jornada = TiposJornada.Tarde }
            };

            Curso cursoTmp = new Curso() { Nombre = "Introducción", Jornada = TiposJornada.Noche };

            // Adicionar otra lista
            escuela.Cursos.AddRange(otraColeccion);
            escuela.Cursos.Add(cursoTmp);

            ImprimirCursosEscuela(escuela);
            WriteLine("Curso.Hash: " + cursoTmp.GetHashCode());

            // Limpia todos los elementos
            //otraColeccion.Clear();

            // Eliminar elementos de una lista
            escuela.Cursos.Remove(cursoTmp);
            //escuela.Cursos.RemoveAt(); // El indice
            //escuela.Cursos.RemoveRange(1, 2); // De un rango a otro

            Predicate<Curso> miAlgoritmo = Predicado; // Debe de regresar un booleano => Protege nuestras condiciones y lo que debe regresar
            //escuela.Cursos.RemoveAll(Predicado); // Elimina todo cuando retorne algo

            escuela.Cursos.RemoveAll(miAlgoritmo); // Elimina todo cuando retorne algo

            // #1 delegado
            //escuela.Cursos.RemoveAll(delegate(Curso cur) { // Crear delegado para hacer la eliminacion de un curso
            //    return cur.Nombre == "Curso de GitLab Avanzado";
            //});

            /// <summary>Comentar</summary>
            /// Para usar etiquetas y tecnico
            ///
            // #2 delegado con lambda
            escuela.Cursos.RemoveAll((Curso cur) => cur.Nombre == "Curso de GitLab Avanzado");

            WriteLine("====================");
            ImprimirCursosEscuela(escuela);


            //Console.WriteLine(escuela);
            Console.WriteLine("====================");
            // cw + tab => abre el log
            //Console.WriteLine(curso1.Nombre + ", " + curso1.UniqueId);
            //Console.WriteLine($"{curso2.Nombre}, {curso2.UniqueId}");
            //Console.WriteLine(curso3);

            // Fallas
            //escuela.Cursos = null;
            //escuela.Cursos = new Curso[0];
            //escuela = null;

            //ImprimirCursosEscuela(escuela);
            //usoDeIf();

        }

        private static bool Predicado(Curso curso)
        {
            return curso.Nombre == "Curso Intermedio C# 2024"; // Retorn true si es igual al seleccionado
        }

        private static void usoDeIf()
        {
            bool rta = 10 == 10; // true
            int cantidad = 10;
            if (rta == false)
            {
                WriteLine("Se cumplio esta condición #1");
            }
            else if (cantidad > 15)
            {
                WriteLine("Se cumplio esta condición #2");
            }
            else
            {
                WriteLine("No se cumplio esta condición");
            }

            if (cantidad > 5 && rta == false)
            {
                WriteLine("Se cumplio esta condición #3");
            }

            if (cantidad > 5 && rta)
            {
                WriteLine("Se cumplio esta condición #4");
            }

            if (cantidad > 5 || !rta)
            {
                WriteLine("Se cumplio esta condición #5");
            }

            //cantidad = 11;
            if ((cantidad > 5 || rta) && (cantidad % 5 == 0))
            {
                WriteLine("Se cumplio esta condición #6");
            }
        }

        private static void usoDeArreglos()
        {
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
