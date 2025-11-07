using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using screenSaver.Classes;
using ScreenSaverFNA.Constants;

namespace ScreenSaverFNA
{
    /// <summary>
    /// Основной класс игры - скринсейвер со снегопадом
    /// </summary>
    public class SnowSaverGame : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private List<Snowflake> snowflakes;
        private Texture2D[] snowflakeTextures;
        private Texture2D backgroundTexture;
        private Random rand;

        /// <summary>
        /// Конструктор класса Game
        /// </summary>
        public SnowSaverGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
            Window.AllowUserResizing = true;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            snowflakeTextures = new Texture2D[AppConstants.SnowflakeImageCount];
            for (var i = 0; i < AppConstants.SnowflakeImageCount; i++)
            {
                snowflakeTextures[i] = Content.Load<Texture2D>($"{AppConstants.SnowflakeResourceNamePrefix}{i + 1}");
            }
            backgroundTexture = Content.Load<Texture2D>(AppConstants.BackgroundResourceName);

            rand = new Random();
            CreateSnowflakes();
        }

        private void CreateSnowflakes()
        {
            snowflakes = new List<Snowflake>();
            var count = rand.Next(AppConstants.MinSnowflakeCount, AppConstants.MaxSnowflakeCount + 1);

            var viewPort = GraphicsDevice.Viewport;
            for (var i = 0; i < count; i++)
            {
                var scale = AppConstants.MinSnowflakeScale + rand.NextDouble() * (AppConstants.MaxSnowflakeScale - AppConstants.MinSnowflakeScale);
                var baseSpeed = AppConstants.MinBaseSpeed + rand.NextDouble() * (AppConstants.MaxBaseSpeed - AppConstants.MinBaseSpeed);
                var speed = (float)baseSpeed;
                speed *= AppConstants.SpeedScaleBase + AppConstants.SpeedScaleMultiplier * (float)scale;

                snowflakes.Add(new Snowflake
                {
                    X = (float)(rand.NextDouble() * viewPort.Width),
                    Y = (float)(rand.NextDouble() * (-viewPort.Height * 2)),
                    Scale = (float)scale,
                    Speed = speed,
                    ImageIndex = rand.Next(snowflakeTextures.Length)
                });
            }
        }

        protected override void Update(GameTime gameTime)
        {
            var keyBoard = Keyboard.GetState();
            var mouse = Mouse.GetState();
            if (keyBoard.GetPressedKeys().Length > 0 ||
                mouse.LeftButton == ButtonState.Pressed ||
                mouse.RightButton == ButtonState.Pressed)
            {
                Exit();
            }

            var elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            var viewPort = GraphicsDevice.Viewport;

            foreach (var flake in snowflakes)
            {
                flake.Y += flake.Speed * AppConstants.TargetFPS * elapsedSeconds;

                if (flake.Y > viewPort.Height + AppConstants.SnowflakeDestroyThreshold)
                {
                    flake.Y = (float)(rand.NextDouble() * AppConstants.SnowflakeRespawnOffset);
                    flake.X = (float)(rand.NextDouble() * viewPort.Width);
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            if (backgroundTexture != null)
            {
                spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
            }

            foreach (var flake in snowflakes)
            {
                Texture2D img = snowflakeTextures[flake.ImageIndex];
                Vector2 position = new Vector2(flake.X, flake.Y);
                Vector2 origin = new Vector2(img.Width / 2f, img.Height / 2f);
                spriteBatch.Draw(img, position, null, Color.White, 0f, origin, flake.Scale, SpriteEffects.None, 0f);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
