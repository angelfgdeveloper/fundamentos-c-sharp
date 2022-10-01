using static System.Console; // Obviamos el Console

namespace CoreEscuela.Util
{
    public static class Printer // static => no permite crear nuevas instancias, por si misma funciona
    {
        public static void DrawLine(int tamanio = 10)
        {
            //string line = "".PadLeft(tamanio, '=');
            WriteLine("".PadLeft(tamanio, '='));
        }

        public static void WriteTitle(string title)
        {
            var tamanio = title.Length + 4;
            DrawLine(tamanio);
            WriteLine($"| {title} |");
            DrawLine(tamanio);
        }

        public static void Beep(int hz = 2000, int time = 500, int count = 1)
        {
            while (count-- > 0)
            {
                Console.Beep(hz, time);
            }
        }
    }
}
