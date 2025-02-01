using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace MonoGameGeoDash
{
    public class Game1 : Game
    {
      // note from 1/4 work more on the character aswellas just other parts u finished with the character jumping but is a little bugged
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D background;
        Texture2D CharacterTexture;
        Backround back1;
        Backround back2;
        Character character;
        KeyboardState state;
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("GeoDashBackground");
            CharacterTexture = Content.Load<Texture2D>("GeoDashCharacter");
            back1 = new Backround(background, new Rectangle(0, 0, 800, 480), Color.White);
            back2 = new Backround(background, new Rectangle(800, 0, 800, 480), Color.White);
            character = new Character(CharacterTexture, new Rectangle(400, 240, 75, 75), Color.White);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            state = Keyboard.GetState();
            back1.Update();
            back2.Update();
            // TODO: Add your update logic here
            character.Update(state);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue); 
            _spriteBatch.Begin();
            back1.Draw(_spriteBatch);
            back2.Draw(_spriteBatch);
            character.Draw(_spriteBatch);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
