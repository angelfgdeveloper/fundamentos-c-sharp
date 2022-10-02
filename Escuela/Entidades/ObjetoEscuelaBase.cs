namespace CoreEscuela.Entidades
{
    // abstract ayuda a heredar de ella, pero no hacer objetos con esta base
    public abstract class ObjetoEscuelaBase
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }
        public ObjetoEscuelaBase() => UniqueId = Guid.NewGuid().ToString(); // Genera un string aleatorio para el ID

        public override string ToString()
        {
            return $"{Nombre}, {UniqueId}";
        }
    }
}
