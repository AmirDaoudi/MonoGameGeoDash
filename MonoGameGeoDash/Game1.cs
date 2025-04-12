using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGameGeoDash
{
    //NOTES:
    //NEED A BETTER COLLSION TRY USING SEPERATING AXIS THEORY OR CORNER COLLISION DETECTION
    //FOR SOME REASON THE CHARACTER IS BROKEN ITS TO BIG BUT CHANGING THE SIZE DOESNT DO ANYTHING AS WELL IT IS PLACED WAY WAY BEFORE THE FLOOR
    //ALSO NEED TO MAKE THE GAME MORE COMPLETE NOT JUST TWO OBSTACLES NEEDS TO LOOK LIKE A FULL GEODASH LEVEL NO BS
    //
    //
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D backgroundTexture;
        private Texture2D characterTexture;
        private Texture2D obstacleTexture;
        private Texture2D groundTexture;

        private Background bg1, bg2;
        private Map ground1, ground2;
        private Character character;
        private JumpingBlocks obstacle1, obstacle2;

        private Rectangle characterStartRect;
        private Rectangle obstacle1StartRect;
        private Rectangle obstacle2StartRect;
        private Rectangle ground1StartRect;
        private Rectangle ground2StartRect;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 480;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            backgroundTexture = Content.Load<Texture2D>("GeoDashBackground");
            characterTexture = Content.Load<Texture2D>("GeoDashCharacter");
            obstacleTexture = Content.Load<Texture2D>("GeoDashBlock");
            groundTexture = Content.Load<Texture2D>("GeoDashBlock");  

            bg1 = new Background(backgroundTexture, new Rectangle(0, 0, 800, 480), Color.White);
            bg2 = new Background(backgroundTexture, new Rectangle(800, 0, 800, 480), Color.White);

          
            ground1 = new Map(groundTexture, new Rectangle(0, 320, 800, 480), Color.White);
            ground2 = new Map(groundTexture, new Rectangle(800, 320, 800, 480), Color.White);

            obstacle1 = new JumpingBlocks(obstacleTexture, new Rectangle(500, 275, 50, 50), Color.White);
            obstacle2 = new JumpingBlocks(obstacleTexture, new Rectangle(800, 225, 50, 100), Color.White);

            character = new Character(characterTexture, new Rectangle(300, 270, characterTexture.Width, characterTexture.Height), Color.White);

            characterStartRect = character.rect;
            obstacle1StartRect = obstacle1.rect;
            obstacle2StartRect = obstacle2.rect;
            ground1StartRect = ground1.rect;
            ground2StartRect = ground2.rect;
        }


            JumpingBlocks closestBlock = null;
        private JumpingBlocks GetClosestBlockToCharacter()
        {
            float closestDistance = float.MaxValue;

            JumpingBlocks[] blocks = new JumpingBlocks[] { obstacle1, obstacle2 };
            foreach (var block in blocks)
            {
                float distance = block.rect.X - (character.rect.X + character.rect.Width);
                if (distance >= 0 && distance < closestDistance)
                {
                    closestDistance = distance;
                    closestBlock = block;
                    return closestBlock;
                }
            }
            return closestBlock;
        }

 
        private void ResetGame()
        {
            character.rect = characterStartRect;
            obstacle1.rect = obstacle1StartRect;
            obstacle2.rect = obstacle2StartRect;
            ground1.rect = ground1StartRect;
            ground2.rect = ground2StartRect;
            bg1.rect = new Rectangle(0, 0, bg1.rect.Width, bg1.rect.Height);
            bg2.rect = new Rectangle(bg1.rect.Width, 0, bg2.rect.Width, bg2.rect.Height);
        }


        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) ||
                GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                Exit();
            }
            KeyboardState state = Keyboard.GetState();
            bg1.Update();
            bg2.Update();
            ground1.Update();
            ground2.Update();
            obstacle1.Update();
            obstacle2.Update();

            JumpingBlocks closestBlock = GetClosestBlockToCharacter();
            character.Update(state, ground1, closestBlock);
            if (Character.Collides(character, closestBlock))
            {
                ResetGame();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue); 

            spriteBatch.Begin();
            bg1.Draw(spriteBatch);
            bg2.Draw(spriteBatch);
            ground1.Draw(spriteBatch);
            ground2.Draw(spriteBatch);
            obstacle1.Draw(spriteBatch);
            obstacle2.Draw(spriteBatch);
            character.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}