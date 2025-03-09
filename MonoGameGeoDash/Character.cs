using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameGeoDash
{
    internal class Character : Sprite
    {
        Vector2 position
        {
            get
            {
                return rect.Location.ToVector2();
            }
            set
            {
                rect.Location = position.ToPoint();
            }
        }

        public int Width
        {

            get
            {
                return rect.Width;
            }

            set
            {
                rect.Width = Width;
            }
        }
        public int Height
        {

            get
            {
                return rect.Height;
            }

            set
            {
                rect.Height = Height;
            }
        }

        float gravity = 0.2f;
        //float spin = 2f;
        float velocity;
        float rotation;
        int timeinair;
        int floor;
        public Character(Texture2D texture, Rectangle rect, Color color) : base(texture, rect, color)
        {
        }
        public void Update(KeyboardState state, JumpingBlocks blocks, Map map, JumpingBlocks closestBlock)
        {
            floor = map.rect.Y + 60;
            if (closestBlock != null && (rect.X + rect.Width) > closestBlock.rect.X && rect.X < closestBlock.rect.X + closestBlock.rect.Width)
            {
                floor = closestBlock.rect.Y + 60;
            }
            else
            {
                floor = map.rect.Y + 60;
            }

            if (state.IsKeyDown(Keys.Space) && rect.Y + rect.Height - floor > -5)
            {
                velocity = -6;
                rect.Y -= 2;
            }
            if (rect.Y + rect.Height < floor)
            {
                velocity += gravity;
            }
            else
            {
                velocity = 0;
            }
            rect.Y += (int)velocity;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rect, null, Color.White, 0, new Vector2(rect.Width, rect.Height), SpriteEffects.None, 0);
        }
        //note from 2/8 finish fixing the rotate and find the time in the air to rotate
    }
}
