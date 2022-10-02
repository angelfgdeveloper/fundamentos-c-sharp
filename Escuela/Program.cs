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

            //var obj = new ObjetoEscuelaBase(); // No se debe entrar a la base
            //polimorfismo();

            List<ObjetoEscuelaBase> listaObjetos = engine.GetObjetoEscuela();
            //engine.Escuela.LimpiarLugar();

            // consultar { de cada obj de la listaObjetos, deonde el ob sea de tipo ILugar seleccioname todo el obj de ILugar}
            // Pueden haber errores silenciosos
            var listaILugar = from obj in listaObjetos
                              where obj is ILugar
                              select (ILugar) obj;

            var listaAlumno = from obj in listaObjetos // Trae todo lo de Alumno
                              where obj is Alumno
                              select (Alumno) obj;

        }

        private static void polimorfismo()
        {
            // POLIMORFISMO
            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.WriteTitle("Pruebas de Polimorfismo");
            Alumno alumnoTest = new Alumno { Nombre = "Claire UnderWood" };

            ObjetoEscuelaBase ob = alumnoTest; // Objetos compatibles
            Printer.WriteTitle("Alumno");
            WriteLine($"Alumno: {alumnoTest.Nombre}");
            WriteLine($"UniqueId: {alumnoTest.UniqueId}");
            WriteLine($"Alumno tipo: {alumnoTest.GetType()}");

            Printer.WriteTitle("ObjetoEscuela");
            WriteLine($"Alumno: {ob.Nombre}");
            WriteLine($"UniqueId: {ob.UniqueId}");
            WriteLine($"Alumno tipo: {ob.GetType()}");

            //var objDummy = new ObjetoEscuelaBase() { Nombre = "Frank UnderWood" };
            //Printer.WriteTitle("ObjetoEscuelaBase");
            //WriteLine($"Alumno: {objDummy.Nombre}");
            //WriteLine($"UniqueId: {objDummy.UniqueId}");
            //WriteLine($"Alumno tipo: {objDummy.GetType()}");

            // No se puede a la inversa
            //alumnoTest = (Alumno) objDummy;

            Evaluacion evaluacion = new Evaluacion() { Nombre = "Evaluación de Math", Nota = 4.5 };
            Printer.WriteTitle("Evaluación");
            WriteLine($"Evaluacion: {evaluacion.Nombre}");
            WriteLine($"Evaluacion: {evaluacion.UniqueId}");
            WriteLine($"Evaluacion: {evaluacion.Nota}");
            WriteLine($"Evaluacion: {evaluacion.GetType()}");

            ob = evaluacion;
            //Printer.WriteTitle("ObjetoEscuela");
            //WriteLine($"Alumno: {ob.Nombre}");
            //WriteLine($"Alumno: {ob.UniqueId}");
            //WriteLine($"Alumno: {ob.GetType()}");

            if (ob is Alumno) // si ob es de tipo alumno (false)
            {
                Alumno alumnoRecuperado = (Alumno) ob; // Alumno recuperado (con cast)
            }

            Alumno alumnoRecuperado2 = ob as Alumno; // un casting

            if (alumnoRecuperado2 != null)
            {
                // code ..
            }

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
