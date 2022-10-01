namespace CoreEscuela.Entidades
{
    public class Curso
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();
        public List<Alumno> Alumnos { get; set; } = new List<Alumno>();

        //public Curso()
        //{
        //    UniqueId = Guid.NewGuid().ToString(); // Genera un string aleatorio para el ID
        //}

        // Contructor corto =>
        public Curso() => UniqueId = Guid.NewGuid().ToString(); // Genera un string aleatorio para el ID
        
    }
}
