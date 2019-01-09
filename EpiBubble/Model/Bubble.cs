using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EpiBubble.Model
{
    public class Bubble : Sprite
    {
        public Bubble(Texture2D texture, Vector2 position, Color color) : base(texture, position, color)
        {
        }
    }
}
