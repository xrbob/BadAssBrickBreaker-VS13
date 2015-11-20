using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace hd_005_statetest01.States
{
    public class NextScreen : BaseGameState
    {

        Texture2D backgroundImage;

        public NextScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {

        }

        protected override void LoadContent()
        {
            ContentManager content = GameRef.Content;

            backgroundImage = content.Load<Texture2D>("Moustache");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (InputHandler.KeyReleased(Keys.Left))
                StateManager.PopState();

            if (InputHandler.KeyReleased(Keys.Space))
                StateManager.PushState(GameRef.GameScreen);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            GameRef.spriteBatch.Begin();

            GameRef.spriteBatch.Draw(backgroundImage, GameRef.ScreenRectangle, Color.White);

            GameRef.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
