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
        protected Vector2 position;
        public Color Color { get; private set; }
        protected Vector2 Velocity { get; set; }
        protected float Speed { get; set; }
        public float Width { get { return texture.Width; } }
        public float Height { get { return texture.Height; } }
        public Vector2 Position
        {
            get { return position; }
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

        public virtual void Update(KeyboardState keyboardState, GameTime gameTime)
        {
            position += (Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
}