namespace ScreenSaverFNA
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
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
