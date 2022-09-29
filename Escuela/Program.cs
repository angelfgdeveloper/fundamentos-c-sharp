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

            Curso curso1 = new Curso()
            {
                Nombre = "Curso de fundamentos C#",
                // UniqueId = "c" => No lo podemos utilizar ya que lo encapsulamos
            };

            Curso curso2 = new Curso()
            {
                Nombre = "Curso Intermedio C#",
                // UniqueId = "c" => No lo podemos utilizar ya que lo encapsulamos
            };

            Curso curso3 = new Curso()
            {
                Nombre = "Curso Avanzado C#",
                // UniqueId = "c" => No lo podemos utilizar ya que lo encapsulamos
            };

            Console.WriteLine(escuela);
            Console.WriteLine("==================");
            // cw + tab => abre el log
            Console.WriteLine(curso1.Nombre + ", " + curso1.UniqueId);
            Console.WriteLine($"{curso2.Nombre}, {curso2.UniqueId}");
            Console.WriteLine(curso3);
        }

    }
}
