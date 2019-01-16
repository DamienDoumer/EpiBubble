using EpiBubble.Helpers;
using EpiBubble.Model;
using EpiBubble.ViewModels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive.Linq;

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
        List<Bubble> _myBubbles;

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
            InitializeBubbles();
            MessageBus.Current.Listen<RestartEventArgs>()
                .Where(e => e.Sender.GetType() == typeof(GamePageViewModel))
                .Subscribe(
                x =>
                {
                    Debug.WriteLine("Restart fired");
                },
                e =>
                {
                    Debug.WriteLine("Error while listening for game restart");
                });
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
            var arrowTexture = Content.Load<Texture2D>("Arrow/Arrow");
            var yPosition = graphics.GraphicsDevice.Viewport.Height - arrowTexture.Height + 5;
            var xPosition = (graphics.GraphicsDevice.Viewport.Width / 2) - (arrowTexture.Width / 2);
            _arrow = new Arrow(arrowTexture, new Vector2(xPosition, yPosition), Color.Green);
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
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            foreach (var item in _myBubbles)
            {
                item.Draw(spriteBatch);
            }
            _arrow.Draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        //rajouter couleur
        public void InitializeBubbles()
        {
            _myBubbles = new List<Bubble>();
            float coordoX = 0;
            float coordoY = 0;
            _myBubbles = new List<Bubble>();

            for (int i = 0; i < 17; i++)
            {
                this._myBubbles.Add(new Bubble(Content.Load<Texture2D>("Bubble"), new Vector2(coordoX, coordoY), Helpers.Helpers.GetRandomBallColor()));
                coordoX += 80;
            }
        }
    }
}