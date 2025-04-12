using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameGeoDash
{
    abstract class Sprite
    {
        public Texture2D texture;
        public Rectangle rect;
        public Color color;

        public Sprite(Texture2D texture, Rectangle rect, Color color)
        {
            this.texture = texture;
            this.rect = rect;
            this.color = color;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rect, color);
        }
    }
}