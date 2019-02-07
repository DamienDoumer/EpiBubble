using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiBubble.Model
{
    public class Sprite
    {
        protected readonly Texture2D texture;
        public Vector2 position;
        public Color Color { get; set; }
        public Vector2 Velocity { get; set; }
        protected float Speed { get; set; }
        public float Width { get { return texture.Width; } }
        public float Height { get { return texture.Height; } }
        public Vector2 Position
        {
            get { return position; }
            set => position = value;
        }
        public Texture2D GetTexture()
        {
            return this.texture;
        }
        float _rotationAngle;
        public float RotationAngle
        {
            get => _rotationAngle;
            set { _rotationAngle = value; }
        }

        public Sprite(Texture2D texture, Vector2 position, Color color)
        {
            Color = color;
            this.texture = texture;
            this.position = position;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(texture, position, Color);
        }

        public virtual void Update(KeyboardState keyboardState, GameTime gameTime)
        {
            position += (Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        //tuncay

        public float GetCoordCenterX()
        {
            return texture.Bounds.Center.X;
        }

        public float GetCoordCenterY()
        {
            return texture.Bounds.Center.Y;
        }

        public float Rayon()
        {
            return texture.Height / 2;
        }
        public float GetLocationX()
        {
            return this.position.X;
        }

        public float GetLocationY()
        {
            return this.position.Y;
        }

        public void SetLocation(float coordX, float coordY)
        {
            this.position.X = coordX;
            this.position.Y = coordY;
        }
    }
}