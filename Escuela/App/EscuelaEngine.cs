using CoreEscuela.Entidades;

namespace CoreEscuela.App
{
    public class EscuelaEngine
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
                            Evaluaciones evaluaciones = new Evaluaciones()
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
    }
}
