namespace CoreEscuela.Entidades
{
    public class Escuela: ObjetoEscuelaBase
    {
        public int AnnioDeCreacion { get; set; } // Hace el mismo efecto que el primero

        public string Pais { get; set; }
        public string Ciudad { get; set; }
        // snippet prop + tab => forma corta
        // snippet propfull + tab => forma larga

        public TiposEscuela TipoEscuela { get; set; }

        //public Curso[] Cursos { get; set; }
        public List<Curso> Cursos { get; set; } = new List<Curso>();

        // #1 constructor normal
        //public Escuela(string nombreEntrada, int annio)
        //{
        //    this.nombre = nombreEntrada;
        //    AnnioDeCreacion = annio;
        //}

        // #2 constructor por tuplas
        public Escuela(string nombreEntrada, int annio) => (Nombre, AnnioDeCreacion) = (nombreEntrada, annio);

        // Argumentos por default en constructor
        public Escuela(
            string nombreEntrada, 
            int annio, 
            TiposEscuela tipo, 
            string pais = "", 
            string ciudad = ""
         )
        {
            (Nombre, AnnioDeCreacion) = (nombreEntrada, annio); // Asignacion por tuplas
            Pais = pais;
            Ciudad = ciudad;
        }

        // Sobrescribir (Hereda del padre)
        public override string ToString()
        {
            // Forma para usar variables dentro de un string $"{aqui_va} aqui texto"
            //return $"Nombre: \"{Nombre}\", Tipo: \"{TipoEscuela}\", \nPaís: \"{Pais}\", Ciudad: \"{Ciudad}\"";
            // {System.Environment.NewLine} => para hacer una nueva linea
            return $"Nombre: \"{Nombre}\", Tipo: \"{TipoEscuela}\", {System.Environment.NewLine}País: \"{Pais}\", Ciudad: \"{Ciudad}\"";
        }

    }
}
