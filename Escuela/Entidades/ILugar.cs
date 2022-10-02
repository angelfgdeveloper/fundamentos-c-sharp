namespace CoreEscuela.Entidades
{
    /// <summary>
    /// Es una estructura que debe tener cualquier objeto, no implementación en la interfaz
    /// Es un contrato, porque como minimo debe e cumplir con estos datos
    /// </summary>
    public interface ILugar
    {
        public string Direccion { get; set; }

        public void LimpiarLugar();
    }
}
