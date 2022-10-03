﻿using CoreEscuela.App;
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
            //parametrosSalida(engine);
            diccionarios(engine);
            


            //engine.Escuela.LimpiarLugar();

            // consultar { de cada obj de la listaObjetos, deonde el ob sea de tipo ILugar seleccioname todo el obj de ILugar}
            // Pueden haber errores silenciosos
            //var listaILugar = from obj in listaObjetos
            //                  where obj is ILugar
            //                  select (ILugar) obj;

            //var listaAlumno = from obj in listaObjetos // Trae todo lo de Alumno
            //                  where obj is Alumno
            //                  select (Alumno) obj;

        }

        private static void diccionarios(EscuelaEngine engine)
        {
            Dictionary<int, string> diccionario = new Dictionary<int, string>();
            diccionario.Add(10, "Pistacho");
            diccionario.Add(223, "Rompopote");

            // Recorrido de un diccionario
            foreach (KeyValuePair<int, string> keyValPair in diccionario)
            {
                WriteLine($"Key: {keyValPair.Key}, Value: {keyValPair.Value}");
            }

            Printer.WriteTitle("Acceso a Diccionario");
            diccionario[0] = "Nuezon"; //Agregando un nuevo elemento
            WriteLine(diccionario[223]); // salida: Rompopote


            Printer.WriteTitle("Otro Diccionario");
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["uno"] = "El número uno mejoro a un 1%";
            WriteLine(dic["uno"]); // salida: El número uno

            dic.Add("dos", "El número dos mejoro a un 2%");
            WriteLine(dic["dos"]);


            var dicTmp = engine.GetDiccionarioObjetos();

        }

        private static void parametrosSalida(EscuelaEngine engine)
        {
            //List<ObjetoEscuelaBase> listaObjetos = engine.GetObjetoEscuela(
            //    traeEvaluaciones: false,
            //    false, false, false
            //);

            // Se convirtio en una tupla
            //var listaObjetos = engine.GetObjetoEscuela(
            //    traeEvaluaciones: true,
            //    false, false, false
            //);

            // 1# Parametros de salida
            //int dummy = 0; // Para omitir
            //var listaObjetos = engine.GetObjetoEscuela(
            //   out int conteoEvaluaciones, out dummy, out dummy, out dummy
            //);

            // 2# Parametros de salida
            var listaObjetos = engine.GetObjetoEscuela(
                out int conteoEvaluaciones,
                out int conteoAlumnos,
                out int conteoAsignaturas,
                out int conteoCursos
            );

            // No debe poder hacer la adcion, con esto lo evitamos en los metodos IReadOnlyList
            //listaObjetos.Add(new Curso { Nombre = "Curso loco" });
            // IEnumerable => es para regresar un objeto generico
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
