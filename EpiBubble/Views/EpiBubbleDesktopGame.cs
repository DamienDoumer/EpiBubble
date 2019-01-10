using EpiBubble.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace EpiBubble
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class EpiBubbleDesktopGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Arrow _arrow;

        public EpiBubbleDesktopGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            var arrowTexture = Content.Load<Texture2D>("Arrow/Astral_Arrow");
            var yPosition = graphics.GraphicsDevice.Viewport.Height - arrowTexture.Height + 5;
            var xPosition = (graphics.GraphicsDevice.Viewport.Width / 2) - (arrowTexture.Width / 2);
            _arrow = new Arrow(arrowTexture, new Vector2(xPosition, yPosition), Color.Green);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            var c = Helpers.Helpers.GetRandomBallColor();
            // TODO: Add your update logic here
            _arrow.Update(Keyboard.GetState(), gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            var arrowTexture = Content.Load<Texture2D>("Arrow/Astral_Arrow");
            var yPosition = graphics.GraphicsDevice.Viewport.Height - arrowTexture.Height + 50;
            List<Arrow> arr = new List<Arrow>();
            for(int i = 0; i < 16;i++)
            {
                var xPosition = (graphics.GraphicsDevice.Viewport.Width / 2) - (arrowTexture.Width / 2) + i;
                var ar = new Arrow(arrowTexture, new Vector2(xPosition, yPosition), Helpers.Helpers.GetRandomBallColor());
                ar.Draw(spriteBatch);
                arr.Add(ar);
            }
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            _arrow.Draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}