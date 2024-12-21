using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameGeoDash
{
    internal class Character:Sprite
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

       

        int YmoveSpeed = 5;
        int XmoveSpeed = 5;
        public Character(Texture2D texture, Rectangle rect, Color color): base(texture, rect, color)
        {           
        }
       
    }
}
