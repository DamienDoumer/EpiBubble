using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        protected readonly Vector2 position;
        public Color Color { get; private set; }

        public Sprite(Texture2D texture, Vector2 position, Color color)
        {
            Color = color;
            this.texture = texture;
            this.position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color);
        }
    }
}
