using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

        float gravity = 0.2f;
       
        float velocity;
        int XmoveSpeed = 5;
        public Character(Texture2D texture, Rectangle rect, Color color): base(texture, rect, color)
        {           
        }
        public void Update(KeyboardState state)
        {
           //for the next time create a way for the character to only be able to jump so high like not to the celieng
            if (state.IsKeyDown(Keys.Space) && rect.Y + rect.Height > 370)
            {
                velocity = -5 ;
                rect.Y -= 2;
            }
            if (rect.Y + rect.Height < 380)
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
            spriteBatch.Draw(texture,rect,null,Color.White, velocity ,new Vector2(rect.Width,rect.Height),SpriteEffects.None, 0);
        }
        //note from 2/1 finish fixing the rotate and add the map
    }
}
