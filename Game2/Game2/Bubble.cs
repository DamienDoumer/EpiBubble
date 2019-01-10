using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2
{
    public class Bubble : Sprite
    {
        private float coordX;
        private float coordY;

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

        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.location, this.color);
        }
    }
}