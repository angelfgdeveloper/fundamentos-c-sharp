using CoreEscuela.Entidades;

namespace CoreEscuela.App
{

    // No puede heredad por que es una clase sellada
    //public class dummy: EscuelaEngine { //code.. }

    // sealed => clase sellada, puedo crear instancia de la clase pero no puedo heredarla
    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine() { }

        // Un metodo si tiene mas de 50 lineas esta mal
        // Una clase debe de tener una sola responsabilidad al igual que los metodos
        public void Inicializar()
        {
            // Parametros opcionales y seleccion de argumento por pais:"bla bla"
            Escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria, pais: "Colombia", ciudad: "Bogota");

            // Datos dummy
            CargarCursos();
            CargarAsignaturas();

            //var listaA = CargarAlumnos();
            //foreach (Curso curso in Escuela.Cursos)
            //{
            //    curso.Alumnos.AddRange(CargarAlumnos());
            //}

            CargarEvaluaciones();
        }

        public Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos()
        {
            var diccionario = new Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>>();

            //IEnumerable<ObjetoEscuelaBase> o = new List<ObjetoEscuelaBase>();
            //List<Curso> c = new List<Curso>();
            //o = (List<ObjetoEscuelaBase>) c; //No lo permite, igualar un objeto por su herencia
            //o = (List<ObjetoEscuelaBase>) c.Cast<ObjetoEscuelaBase>();

            diccionario.Add(LlaveDiccionario.Escuela, new[] { Escuela }); // Arreglo de una sola posicion
            //diccionario.Add("Cursos", Escuela.Cursos[0]);
            //diccionario.Add("Cursos", Escuela.Cursos[1]); // Excepcion por la misma llave

            diccionario.Add(LlaveDiccionario.Curso, Escuela.Cursos.Cast<ObjetoEscuelaBase>()); //Conversión


            return diccionario;
        }

        /// <summary>
        /// Uso de parametros de salida y opcionales
        /// </summary>
        /// <param name="traeEvaluaciones"></param>
        /// <param name="traeAlumnos"></param>
        /// <param name="traeAsignaturas"></param>
        /// <param name="traeCursos"></param>
        /// <returns></returns>
        #region Sobrecargas y lista de solo lectura
        // #1 Sobrecarga
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuela(
           bool traeEvaluaciones = true,
           bool traeAlumnos = true,
           bool traeAsignaturas = true,
           bool traeCursos = true
        )
        {
            return GetObjetoEscuela(out int dummy, out dummy, out dummy, out dummy);
        }

        // #2 Sobrecarga
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuela(
            out int conteoEvaluaciones,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
        )
        {
            return GetObjetoEscuela(out conteoEvaluaciones, out int dummy, out dummy, out dummy);
        }

        // #3 Sobrecarga
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuela(
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
        )
        {
            return GetObjetoEscuela(out conteoEvaluaciones, out conteoAlumnos, out int dummy, out dummy);
        }

        // #3 Sobrecarga
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuela(
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            out int conteoAsignaturas,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
        )
        {
            return GetObjetoEscuela(out conteoEvaluaciones, out conteoAlumnos, out conteoAsignaturas, out int dummy);
        }

        // #1 Retorna una lista y un entero (List<ObjetoEscuelaBase>, int)
        // #2 Retorna parametros de salida
        // #3 IReadOnlyList lista de solo lectura
        public /*(List<ObjetoEscuelaBase>, int)*/ IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuela(
            // Parametros de salida
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            out int conteoAsignaturas,
            out int conteoCursos,

            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
        )
        {
            //int conteoEvaluaciones = 0;
            conteoEvaluaciones = 0;
            conteoAlumnos = 0;
            conteoAsignaturas = 0;
            conteoCursos = 0;

            List<ObjetoEscuelaBase> listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(Escuela);

            if (traeCursos)
                listaObj.AddRange(Escuela.Cursos);

            conteoCursos += Escuela.Cursos.Count; // contador
            foreach (Curso curso in Escuela.Cursos)
            {
                conteoAsignaturas += curso.Asignaturas.Count; // contador
                conteoAlumnos += curso.Alumnos.Count; // contador

                if (traeAsignaturas)
                    listaObj.AddRange(curso.Asignaturas);

                if (traeAlumnos)
                    listaObj.AddRange(curso.Alumnos);

                if (traeEvaluaciones)
                {
                    foreach (Alumno alumno in curso.Alumnos)
                    {
                        listaObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count; // sumar la cantidad de cada uno de los alumnos
                    }
                }
            }

            //return (listaObj, conteoEvaluaciones);
            return listaObj;
        }
        #endregion

        /// <summary>
        /// Se agrupa los métodos usando #region & #endregion entre cada bloque de métodos
        /// </summary>
        #region Métodos de Carga
        private void CargarEvaluaciones()
        {
            foreach (Curso curso in Escuela.Cursos)
            {
                foreach (Asignatura asignatura in curso.Asignaturas)
                {
                    foreach (Alumno alumno in curso.Alumnos)
                    {
                        var rnd = new Random(Environment.TickCount); // TickCount => número en milliseconds cuando inicia la app

                        for (int i = 0; i < 5; i++)
                        {
                            Evaluacion evaluaciones = new Evaluacion()
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Nota = (double)(5 * rnd.NextDouble()), // número aleatorio doble entre 0 y 5 (casteo a double)
                                Alumno = alumno
                            };

                            alumno.Evaluaciones.Add(evaluaciones);
                        }
                    }
                }
            }
        }

        // #2
        private void CargarAsignaturas()
        {
            foreach (Curso curso in Escuela.Cursos)
            {
                List<Asignatura> listaAsignaturas = new List<Asignatura>()
                {
                    new Asignatura() { Nombre = "Matemáticas" },
                    new Asignatura() { Nombre = "Educación Física" },
                    new Asignatura() { Nombre = "Ingles" },
                    new Asignatura() { Nombre = "Ciencias Naturales" },
                    new Asignatura() { Nombre = "Matemáticas" },
                };

                curso.Asignaturas = listaAsignaturas;
            }
        }

        // #3
        private List<Alumno> generarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };

            // Producto carteciano combinacion de todos contra todos (linq) son las queries de c#
            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno() { Nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList(); // Take para truncar y decirle que me regrese tantos alumnos
        }

        // #1
        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>()
            {
                new Curso() { Nombre = "Curso de fundamentos C#", Jornada = TiposJornada.Maniana },
                new Curso() { Nombre = "Curso Intermedio C#", Jornada = TiposJornada.Maniana },
                new Curso() { Nombre = "Curso Avanzado C#", Jornada = TiposJornada.Maniana },
                new Curso() { Nombre = "Curso de Github & Git", Jornada = TiposJornada.Tarde },
                new Curso() { Nombre = "Curso de GitLab Avanzado", Jornada = TiposJornada.Tarde }
            };

            Random rnd = new Random();
            foreach (Curso curso in Escuela.Cursos)
            {
                int cantidadRandom = rnd.Next(5, 20); // Me genera un número entre 5 a 20 estudiantes
                curso.Alumnos = generarAlumnosAlAzar(cantidadRandom);
            }
        }

        #endregion
    }
}
