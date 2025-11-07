namespace ScreenSaverFNA.Classes
{
    /// <summary>
    /// Снежинка
    /// </summary>
    public class Snowflake
    {
        /// <summary>
        /// Координата X позиции снежинки
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Координата Y позиции снежинки
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Масштаб снежинки (размер)
        /// </summary>
        public float Scale { get; set; }

        /// <summary>
        /// Скорость падения снежинки
        /// </summary>
        public float Speed { get; set; }

        /// <summary>
        /// Индекс изображения снежинки в коллекции изображений
        /// </summary>
        public int ImageIndex { get; set; }
    }
}
