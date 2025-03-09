using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Concurrent;
using System.Collections.Generic;
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
        Texture2D JumpingBlocksTexture;
        Backround back1;
        Backround back2;
        Map Map1;
        Map Map2;
        Character character;
        JumpingBlocks block;
        JumpingBlocks block2;
        KeyboardState state;
        JumpingBlocks closestBlock = null;

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
            JumpingBlocksTexture = Content.Load<Texture2D>("GeoDashBlock");
            back1 = new Backround(background, new Rectangle(0, 0, 800, 480), Color.White);
            back2 = new Backround(background, new Rectangle(800, 0, 800, 480), Color.White);
            character = new Character(CharacterTexture, new Rectangle(400, 240, 75, 75), Color.White);
            block = new JumpingBlocks(JumpingBlocksTexture, new Rectangle(500, 275, 50, 50), Color.White);
            block2 = new JumpingBlocks(JumpingBlocksTexture, new Rectangle(800, 225, 50, 100), Color.White);
            Map1 = new Map(JumpingBlocksTexture, new Rectangle(0, 320, 800, 480), Color.White);
            Map2 = new Map(JumpingBlocksTexture, new Rectangle(800, 320, 800, 480), Color.White);
            // TODO: use this.Content to load your game content here
        }
        public JumpingBlocks GetClosestBlockToCharacter()
        {
            float closestDistance = float.MaxValue;

            List<JumpingBlocks> blocks = new List<JumpingBlocks> { block, block2 }; 

            foreach (var blk in blocks)
            {
                float distance = blk.rect.X - (character.rect.X + character.rect.Width);
                if (distance > 0 && distance < closestDistance)
                {
                    closestDistance = distance;
                    closestBlock = blk;
                }
            }

            return closestBlock;
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            state = Keyboard.GetState();
            back1.Update();
            back2.Update();
            block.Update();
            block2.Update();
            Map1.Update();
            Map2.Update();

            JumpingBlocks closestBlock = GetClosestBlockToCharacter();
            character.Update(state, block, Map1, closestBlock);

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue); 
            _spriteBatch.Begin();
            back1.Draw(_spriteBatch);
            back2.Draw(_spriteBatch);
            character.Draw(_spriteBatch);
            block.Draw(_spriteBatch);
            block2.Draw(_spriteBatch);
            Map1.Draw(_spriteBatch);
            Map2.Draw(_spriteBatch);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
