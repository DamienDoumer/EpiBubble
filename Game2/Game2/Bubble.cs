using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2
{
    public class Bubble : Sprite
    {
        

        public Bubble(Texture2D text, Vector2 location, Color color) : base(text, location, color)
        {
            
        }

        

        
    }

    public class Sprite
    {
        private Texture2D texture;
        private Vector2 location;
        public Color color;

        public Sprite(Texture2D text, Vector2 location, Color color)
        {
            this.texture = text;
            this.location = location;
            this.color = color;
        }

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
            return this.location.X;
        }

        public float GetLocationY()
        {
            return this.location.Y;
        }

        public void SetLocation(float coordX, float coordY)
        {
            this.location.X = coordX;
            this.location.Y = coordY;
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.location, this.color);
        }
    }
}