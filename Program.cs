namespace ScreenSaverFNA
{
    /// <summary>
    /// Класс точки входа в приложение.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        public static void Main(string[] args)
        {
            using (var game = new SnowSaverGame())
            {
                game.Run();
            }
        }
    }
}
