﻿using System;
using System.Collections.Generic;
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
            UpdateVelocityFromKeyboard(keyboardState);
            base.Update(keyboardState, gameTime);
        }

        private void UpdateVelocityFromKeyboard(KeyboardState keyboardState)
        {
            if(keyboardState.IsKeyDown(Keys.Left))
            {
                RotationAngle = RotationAngle + -0.1f;
            }
            else if(keyboardState.IsKeyDown(Keys.Right))
            {
                RotationAngle = RotationAngle + 0.1f;
            }
        }
    }
}
