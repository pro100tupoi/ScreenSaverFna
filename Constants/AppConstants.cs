namespace ScreenSaverFNA.Constants
{
    /// <summary>
    /// Глобальные константы приложения
    /// </summary>
    public static class AppConstants
    {
        /// <summary>
        /// Минимальное количество снежинок на экране
        /// </summary>
        public const int MinSnowflakeCount = 500;

        /// <summary>
        /// Максимальное количество снежинок на экране
        /// </summary>
        public const int MaxSnowflakeCount = 800;

        /// <summary>
        /// Минимальный масштаб снежинки
        /// </summary>
        public const double MinSnowflakeScale = 0.01;

        /// <summary>
        /// Максимальный масштаб снежинки
        /// </summary>
        public const double MaxSnowflakeScale = 0.03; // 0.01 + 0.02

        /// <summary>
        /// Минимальная базовая скорость падения снежинки
        /// </summary>
        public const double MinBaseSpeed = 0.15;

        /// <summary>
        /// Максимальная базовая скорость падения снежинки
        /// </summary>
        public const double MaxBaseSpeed = 7.85; // 0.15 + 7.7

        /// <summary>
        /// Базовый множитель скорости в зависимости от масштаба
        /// </summary>
        public const float SpeedScaleBase = 0.95f;

        /// <summary>
        /// Дополнительный множитель скорости в зависимости от масштаба
        /// </summary>
        public const float SpeedScaleMultiplier = 0.1f;

        /// <summary>
        /// Смещение по Y для пересоздания снежинки (когда снежинка уходит за верхнюю границу)
        /// </summary>
        public const int SnowflakeRespawnOffset = -100;

        /// <summary>
        /// Пороговое значение для уничтожения снежинки (когда снежинка уходит за нижнюю границу)
        /// </summary>
        public const int SnowflakeDestroyThreshold = 50; // если Y > Height + 50

        /// <summary>
        /// Целевой FPS для нормализации скорости анимации
        /// </summary>
        public const float TargetFps = 60f; // используется для нормализации скорости

        /// <summary>
        /// Префикс имени ресурса для изображений снежинок
        /// </summary>
        public const string SnowflakeResourceNamePrefix = "snowflake";

        /// <summary>
        /// Количество доступных изображений снежинок
        /// </summary>
        public const int SnowflakeImageCount = 6;

        /// <summary>
        /// Имя ресурса для фонового изображения
        /// </summary>
        public const string BackgroundResourceName = "background";
    }
}
