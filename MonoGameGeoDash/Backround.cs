using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameGeoDash
{
    internal class Background
    {
        public Texture2D texture;
        public Rectangle rect;
        public Color color;

        public Background(Texture2D texture, Rectangle rect, Color color)
        {
            this.texture = texture;
            this.rect = rect;
            this.color = color;
        }
        public void Update()
        {
            rect.X -= 1; 

            if (rect.X <= -rect.Width)
            {
                rect.X = rect.Width;  
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rect, color);
        }
    }
}