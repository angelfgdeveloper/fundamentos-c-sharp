using CoreEscuela.Entidades;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            Escuela escuela1 = new Escuela("Platzi Academy", 2012);
            escuela1.Pais = "Colombia";
            escuela1.Ciudad = "Bogota";

            //Uso de enum =>
            escuela1.TipoEscuela = TiposEscuela.Primaria;

            // Parametros opcionales y seleccion de argumento por pais:"bla bla"
            Escuela escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria, pais: "Colombia", ciudad: "Bogota");

            Console.WriteLine(escuela);
        }

    }
}
