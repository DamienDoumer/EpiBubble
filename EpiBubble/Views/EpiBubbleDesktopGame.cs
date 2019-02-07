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
using EpiBubble.Helpers;

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
        int yPosition;
        int xPosition;
        //tuncay
        List<Bubble> myBubbles;
        List<List<Bubble>> myBubbles15Row;
        private Vector2 myPos;
        private Vector2 myMove;
        private Bubble bShoot;
        private Color bShootColor;

        public EpiBubbleDesktopGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 544;
            //graphics.PreferredBackBufferHeight = 700;
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
            this.InitialBubbles3();
            this.bShoot = this.InitBubbleToShoot();
            this.bShootColor = this.bShoot.Color;
            //InitializeBubbles();
            MessageBus.Current.Listen<SetupDialogClosedEventArgs>()
                .Subscribe(
                x =>
                {
                    _arrow.Color = new Color(x.PreferedArrowColor.R, x.PreferedArrowColor.G, x.PreferedArrowColor.B);
                },
                e =>
                {
                    Debug.WriteLine("Error while listening for game restart");
                });

            //initi la pos de la bubble
            this.myPos = this.bShoot.Position;
            this.myMove = Vector2.Zero;
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
            //yPosition = graphics.GraphicsDevice.Viewport.Height - arrowTexture.Height + 5;
            //xPosition = (graphics.GraphicsDevice.Viewport.Width / 2) - (arrowTexture.Width / 2);
            xPosition = 527 / 2;
            yPosition = 300 + 100;
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
            bShoot.Update(Keyboard.GetState(), gameTime);

            this.myPos += this.myMove;
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
            //foreach (var item in _myBubbles)
            //{
            //  item.Draw(spriteBatch);
            //}
            _arrow.Draw(spriteBatch);
            foreach (var myBubbles in myBubbles15Row)
            {
                foreach (var item in myBubbles)
                {
                    item.Draw(spriteBatch);
                }
            }
            this.bShoot.Draw(spriteBatch, this.myPos);
            bShoot.ShootingBubble = true;
            // spriteBatch.Draw(this.bShoot.GetTexture(), this.myPos, this.bShootColor);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public void Shoot(int vitesse)
        {
            bShoot.position.X = (float)(myPos.X + (vitesse * (Math.Cos(bShoot.RotationAngle))));
            bShoot.position.Y = (float)(myPos.Y + (vitesse * (Math.Sin(bShoot.RotationAngle))));
        }

        //rajouter couleur
        /// <summary>
        /*
     
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

    */

        public Bubble InitBubbleToShoot()
        {
            //return new Bubble(Content.Load<Texture2D>("Bubble"), new Vector2(xPosition, yPosition+32), Helpers.Helpers.GetRandomBallColor());
            return new Bubble(Content.Load<Texture2D>("Bubble"), new Vector2(527/2,300), Helpers.Helpers.GetRandomBallColor());
        }

        // créer une ligne de 17 bubble a une position (0,cY)
        public System.Collections.Generic.List<Bubble> InitialiseBubbles(float cX, float cY)
        {
            float coordoX = cX;
            float coordoY = cY;
            myBubbles = new System.Collections.Generic.List<Bubble>();
            //hh = new Helper();
            var colors = Helpers.Helpers.RandomColorDefault();
            for (int i = 0; i < 17; i++)
            {
                this.myBubbles.Add(new Bubble(Content.Load<Texture2D>("Bubble"), new Vector2(coordoX, coordoY), colors[i]));
                coordoX += 31;
            }
            return myBubbles;
        }

        public void InitialBubbles3()
        {
            float x = 0;
            float w = 0;
            myBubbles15Row = new System.Collections.Generic.List<System.Collections.Generic.List<Bubble>>();

            for (int i = 0; i < 3; i++)
            {
                if (i == 1)
                {
                    w += 15;
                }
                else
                {
                    w = 0;
                }
                this.myBubbles15Row.Add(this.InitialiseBubbles(w, x));
                x += 31;
            }
        }

        //booleen pour inserer un etage tout les 6 coups
        public bool PossibleToInsertNewRow(int nb)
        {
            if (nb == 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // pour verifier si le joueur a perdu ou non
        public bool IsLose(int nbRow)
        {
            if (nbRow >= 15)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //ajouter une nouvelle ligne avec un decalage de coordX
        public void AddNewRow(float coordXdec)
        {
            System.Collections.Generic.List<System.Collections.Generic.List<Bubble>> tmp = new System.Collections.Generic.List<System.Collections.Generic.List<Bubble>>();
            int coordX = 0;

            foreach (var line in this.myBubbles15Row)
            {
                foreach (var bubble in line)
                {
                    bubble.SetLocation(bubble.GetLocationX(), bubble.GetLocationY() + 31);
                }
                tmp.Add(line);
            }
            this.myBubbles15Row.Clear();
            this.myBubbles15Row.Add(this.InitialiseBubbles(coordXdec, 0));
            foreach (var item in tmp)
            {
                this.myBubbles15Row.Add(item);
            }
            // ici on test si le remove fonctionne : utilisation : this.myBubbles15Row[3][2] remplacer ca pas la bubble lancé
            this.RemoveBubbleIf3Shot(this.EveryBubbleToRemove(this.ListNextToBubbleSameColor(this.myBubbles15Row[3][2])));

        }

        //return la distance entre 2 bubble
        public double Distance(double b1X, double b2X, double b1Y, double b2Y)
        {
            double op = ((b2X - b1X) * (b2X - b1X)) + ((b2Y - b1Y) * (b2Y - b1Y));
            return System.Math.Sqrt(op);
        }

        // return true si il y a colision entre c'est 2 elements
        public bool IsCollision(Bubble b1, Bubble b2)
        {
            float b1X = b1.GetCoordCenterX();
            float b2X = b2.GetCoordCenterX();
            float b1Y = b1.GetCoordCenterY();
            float b2Y = b2.GetCoordCenterY();
            if (this.Distance(b1X, b2X, b1Y, b2Y) < (b1.Rayon() + b2.Rayon()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // retourne la liste des bulle voisin de b ssi ils sont de la meme couleur, b est la bubble tiré
        public System.Collections.Generic.List<Bubble> ListNextToBubbleSameColor(Bubble b)
        {
            System.Collections.Generic.List<Bubble> res = new System.Collections.Generic.List<Bubble>();
            //float bx = b.GetCoordCenterX();
            //float by = b.GetCoordCenterY();
            float bx = b.GetLocationX();
            float by = b.GetLocationY();
            Color color = b.Color;
            float rayon = b.Rayon();

            Bubble b1 = this.ReturnBubbleWithCoordIs(bx - 31, by);
            Bubble b2 = this.ReturnBubbleWithCoordIs(bx + 31, by);
            Bubble b3 = this.ReturnBubbleWithCoordIs(bx - rayon, by - 31);
            Bubble b4 = this.ReturnBubbleWithCoordIs(bx - rayon, by + 31);
            Bubble b5 = this.ReturnBubbleWithCoordIs(bx + rayon, by - 31);
            Bubble b6 = this.ReturnBubbleWithCoordIs(bx + rayon, by + 31);

            if (b1 != null)
            {
                if (b1.Color == color)
                {
                    res.Add(b1);
                }
            }
            if (b2 != null)
            {
                if (b2.Color == color)
                {
                    res.Add(b2);
                }
            }
            if (b3 != null)
            {
                if (b3.Color == color)
                {
                    res.Add(b3);
                }
            }
            if (b4 != null)
            {
                if (b4.Color == color)
                {
                    res.Add(b4);
                }
            }
            if (b5 != null)
            {
                if (b5.Color == color)
                {
                    res.Add(b5);
                }
            }
            if (b6 != null)
            {
                if (b6.Color == color)
                {
                    res.Add(b6);
                }
            }
            res.Add(b);
            return res;
        }

        //retourne la liste de tous les bubbles a supprimer
        public List<Bubble> EveryBubbleToRemove(System.Collections.Generic.List<Bubble> listB)
        {
            System.Collections.Generic.List<Bubble> res = new System.Collections.Generic.List<Bubble>();

            foreach (var bubble in listB)
            {
                List<Bubble> tmp = new List<Bubble>(this.ListNextToBubbleSameColor(bubble));
                foreach (var i in tmp)
                {
                    res.Add(i);
                }
            }
            foreach (var i in listB)
            {
                res.Add(i);
            }
            return res;
        }

        //supprime les bubble si il y en a au moins 3 de la meme couleur
        public bool RemoveBubbleIf3Shot(List<Bubble> listB)
        {
            if (PossibleToRemoveNextTo(listB))
            {
                foreach (var bubble in listB)
                {
                    this.RemoveBubble(bubble);

                }
                return true;
            }
            return false;
        }

        //retourn une bulle qui a pour coordonné (coordX, coordY) si pas de bulle return null
        public Bubble ReturnBubbleWithCoordIs(float coordX, float coordY)
        {
            foreach (var line in this.myBubbles15Row)
            {
                foreach (var bubble in line)
                {
                    if ((bubble.GetLocationX() == coordX) & (bubble.GetLocationY() == coordY))
                    {
                        return bubble;
                    }
                }
            }
            return null;
        }

        //supprime la bubble b 
        public bool RemoveBubble(Bubble b)
        {
            foreach (var line in this.myBubbles15Row)
            {
                foreach (var bubble in line)
                {
                    if ((b.GetLocationX() == bubble.GetLocationX()) & (b.GetLocationY() == bubble.GetLocationY()))
                    {
                        bubble.SetLocation(-100, -100);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PossibleToRemoveNextTo(System.Collections.Generic.List<Bubble> list)
        {
            int size = list.Count;
            return size > 2;
        }
    }
}