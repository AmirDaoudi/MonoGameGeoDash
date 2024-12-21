using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameGeoDash
{
    internal class Backround : Sprite
    {
        public Backround(Texture2D texture, Rectangle rect, Color color) : base(texture, rect, color)
        {
        }
        public void Update()
        {
            rect.X--;
            if(rect.X <= -rect.Width)
            {
                rect.X = rect.Width;
            }
        }
    }
}
