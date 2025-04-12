using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGameGeoDash
{
    internal class Character : Sprite
    {
        private float gravity = 0.2f;   
        private float velocity = 0f;     
        private float rotation = 0f;
        private int floor = 360;          

        public Character(Texture2D texture, Rectangle rect, Color color)
            : base(texture, rect, color)
        {
        }

        public void Update(KeyboardState state, Map map, JumpingBlocks closestBlock)
        {
           
            floor = map.rect.Y + 30;

            if (closestBlock != null &&
                rect.X + rect.Width > closestBlock.rect.X &&    
                rect.X < closestBlock.rect.X + closestBlock.rect.Width) 
            {
                floor = closestBlock.rect.Y + 30;
            }

            if (state.IsKeyDown(Keys.Space) && (rect.Y + rect.Height >= floor - 5))
            {
                velocity = -10f;   
                rect.Y -= 2;    
            }

            if (rect.Y + rect.Height < floor)
            {
                velocity += gravity; 
                rotation += 0.1f;     
            }
            else
            {
                velocity = 0f;
                rotation = 0f;      
                rect.Y = floor - rect.Height;
            }

            rect.Y += (int)velocity;
        }
        public static Boolean Collides(Character character, JumpingBlocks block)
        {
            Rectangle r1 = character.rect;
            Rectangle r2 = block.rect;

            if (!r1.Intersects(r2))
            {
                return false;
            }

            if (r2.Contains(new Point(r1.Left, r1.Top)) ||
                r2.Contains(new Point(r1.Right, r1.Top)) ||
                r2.Contains(new Point(r1.Left, r1.Bottom)) ||
                r2.Contains(new Point(r1.Right, r1.Bottom)))
            {
                return true;
            }

            if (r1.Contains(new Point(r2.Left, r2.Top)) ||
                r1.Contains(new Point(r2.Right, r2.Top)) ||
                r1.Contains(new Point(r2.Left, r2.Bottom)) ||
                r1.Contains(new Point(r2.Right, r2.Bottom)))
            {
                return true;
            }

            return false;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 origin = new Vector2(texture.Width / 2f, texture.Height / 2f);
            spriteBatch.Draw(texture, new Vector2(rect.X, rect.Y), null, Color.White, rotation, origin, 1.0f, SpriteEffects.None, 0f);
        }
    }
}