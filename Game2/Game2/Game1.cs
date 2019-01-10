using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace Game2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //private Texture2D paddle;
        //private Bubble bubble;
        private System.Collections.Generic.List<Bubble> myBubbles;
        // myBubbles15Row va contenir les lignes
        //private System.Collections.Generic.List<System.Collections.Generic.List<Bubble>> myBubbles15Row;
        //private string bubbleImgName = "Paddle";   
       
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 527;
            graphics.PreferredBackBufferHeight = 700;
            graphics.IsFullScreen = false;
            Window.Title = "BubbleGame";
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
            //bubble = new Bubble(Content.Load<Texture2D>("bubble/Bubble"), new Vector2(this.coordX, this.coordY));
            // TODO: use this.Content to load your game content here
            this.InitialiseBubbles(0);
           // this.Initialise15Row();
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            //foreach (var item in myBubbles)
            //foreach (var myBubbles in myBubbles15Row)
            //{
                foreach (var item in myBubbles)
                {
                    item.Draw(spriteBatch);
                }
            //}
            spriteBatch.End();
            base.Draw(gameTime);
        }

        //default
  //      public System.Collections.Generic.List<Color> randomColor()
  //      {
  //          System.Collections.Generic.List<Color> res = new System.Collections.Generic.List<Color>();
  //          System.Random rnd = new System.Random();

  //          for (int i = 0; i < 17;i++)
  //          {
  //              Color c = Color.White;
  //              int number = rnd.Next(1, 13);

  //              if (number == 1) {
  //                  res.Add(Color.Black);
   //             }
  //              if (number == 2) {
    //                res.Add(Color.Silver);
  //              }
    //            if (number == 3) {
      //              res.Add(Color.Gray);
    //            }
    //            if (number == 4)
    //            {
      //              res.Add(Color.Maroon); 
      /*                }
                if (number == 5)
                {
                    res.Add(Color.Red);
                }
                if (number == 6)
                {
                    res.Add(Color.Purple);
                }
                if (number == 7)
                {
                    res.Add(Color.Fuchsia);
                }
                if (number == 8)
                {
                    res.Add(Color.Green);
                }
                if (number == 9)
                {
                    res.Add(Color.Lime);
                }
                if (number == 10)
                {
                    res.Add(Color.Yellow);
                }
                if (number == 11)
                {
                    res.Add(Color.Blue);
                }
                if (number == 12)
                {
                    res.Add(Color.Cyan);
                }
                    
            }
            return res;
        } */

        public System.Collections.Generic.List<Color> randomColorDefault()
        {
            System.Collections.Generic.List<Color> res = new System.Collections.Generic.List<Color>();
            System.Random rnd = new System.Random();

            for (int i = 0; i < 17; i++)
            {
                Color c = Color.White;
                int number = rnd.Next(1, 7);

                if (number == 1)
                {
                    res.Add(Color.Blue);
                }
                if (number == 2)
                {
                    res.Add(Color.Red);
                }
                if (number == 3)
                {
                    res.Add(Color.Cyan);
                }
                if (number == 4)
                {
                    res.Add(Color.Yellow);
                }
                if (number == 5)
                {
                    res.Add(Color.Fuchsia);
                }
                if (number == 6)
                {
                    res.Add(Color.Lime);
                }
            }
            return res;
        }

        public System.Collections.Generic.List<Bubble> InitialiseBubbles(float cY)
        {
            float coordoX = 0;
            float coordoY = cY;
            myBubbles = new System.Collections.Generic.List<Bubble>();
            System.Collections.Generic.List<Color> colors = this.randomColorDefault();
            for (int i = 0; i < 17;i++) {                   
                this.myBubbles.Add(new Bubble(Content.Load<Texture2D>("bubble/Bubble"), new Vector2(coordoX, coordoY), colors[i]));
                coordoX += 31;
            }
            return myBubbles;
        }

//        public void Initialise15Row()
//        {
//            float c = 0;
//            myBubbles15Row = new System.Collections.Generic.List<System.Collections.Generic.List<Bubble>>();

//            for (int i = 0;i < 15;i++)
  //          {
    //            this.myBubbles15Row.Add(this.InitialiseBubbles(c));
      //          c += 31;
        //    }
     //   }
    }
}
