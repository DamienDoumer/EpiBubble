using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EpiBubble.Model
{
    public class Bubble : Sprite
    {
        public bool ShootingBubble { get; set; }
        public Bubble(Texture2D texture, Vector2 position, Color color) : base(texture, position, color)
        {
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
 
        public void Move(float speed, float angle)
        {
            RotationAngle = angle;

            Vector2 direction = new Vector2((float)Math.Cos(MathHelper.ToRadians(90)),
                                            (float)Math.Sin(MathHelper.ToRadians(90)));
            //direction.Normalize();
            Position += direction * speed;
        }

        public override void Update(KeyboardState keyboardState, GameTime gameTime)
        {
            if (ShootingBubble)
            {
                if (keyboardState.IsKeyDown(Keys.Space) || Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    //shoot bubble
                    Position = new Vector2(600, 300);
                }
                //var xPosition = 527 / 2;
                //var yPosition = 300 + 100;
                var newVelocity = new Vector2(Position.X*100, Position.Y*50);
                Velocity = newVelocity;
            }
            Position += Velocity;
            //base.Update(keyboardState, gameTime);
        }
    }
}