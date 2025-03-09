using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameGeoDash
{
    public class JumpingBlocks
    {
        Texture2D texture;
        public Rectangle rect;
        Color color;
        public JumpingBlocks(Texture2D texture, Rectangle rect, Color color)
        {
            this.texture = texture;
            this.rect = rect;
            this.color = color;
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(texture, rect, color);
        }
        public void Update()
        {
            rect.X--;
            if (rect.X <= -rect.Width)
            {
                rect.X = 800;
            }
        }
        
    }
}
