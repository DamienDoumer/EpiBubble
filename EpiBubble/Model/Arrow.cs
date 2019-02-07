using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EpiBubble.Model
{
    public class Arrow : Sprite
    {
        public Arrow(Texture2D texture, Vector2 position, Color color) : base(texture, position, color)
        {
            Speed = 300;
            RotationAngle = 0;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int) Position.X,
                                                    (int) Position.Y, 
                                                    texture.Width,
                                                    texture.Height), 
                                                    null,
                                                    Color,
                                                    RotationAngle,
                                                    new Vector2(texture.Width / 2f, texture.Height / 2f),
                                                    SpriteEffects.None,
                                                    0);
        }

        public override void Update(KeyboardState keyboardState, GameTime gameTime)
        {
            var mouseState = Mouse.GetState();
            if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.Right))
            {
                UpdateVelocityFromKeyboard(keyboardState);
            }
            else
            {
                // UpdateVelocityFromMouse(mouseState);
            }
            base.Update(keyboardState, gameTime);
        }

        private void UpdateVelocityFromMouse(MouseState mouseState)
        {
            if (mouseState.Position.X > 0)
            {
                if (RotationAngle < 1.1)
                    RotationAngle = RotationAngle + 0.1f;
            }
            else
            {
                if (RotationAngle > -1.1)
                    RotationAngle = RotationAngle + -0.1f;
            }
        }

        private void UpdateVelocityFromKeyboard(KeyboardState keyboardState)
        {
            if(keyboardState.IsKeyDown(Keys.Left))
            {
                if(RotationAngle > -1.1)
                    RotationAngle = RotationAngle + -0.1f;
            }
            else if(keyboardState.IsKeyDown(Keys.Right))
            {
                if (RotationAngle < 1.1)
                    RotationAngle = RotationAngle + 0.1f;
            }
        }
    }
}
