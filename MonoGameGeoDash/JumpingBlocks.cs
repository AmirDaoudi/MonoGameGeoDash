using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonoGameGeoDash
{
    public class JumpingBlocks
    {
        public Texture2D texture;
        public Rectangle rect;
        public Color color;

        public JumpingBlocks(Texture2D texture, Rectangle rect, Color color)
        {
            this.texture = texture;
            this.rect = rect;
            this.color = color;
        }
        public void Update(JumpingBlocks block)
        {
            rect.X -= 3;

            if (rect.X <= -rect.Width)
            {
                int rndm = new Random().Next(400, 1000);
                rect.X = block.rect.X + rndm;  
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rect, color);
        }
    }
}