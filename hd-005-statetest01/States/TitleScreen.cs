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
    public class TitleScreen : BaseGameState
    {

        Texture2D promoImage;
        Color fader;

        public TitleScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {
            
        }

        protected override void LoadContent()
        {
            ContentManager content = GameRef.Content;

            promoImage = content.Load<Texture2D>("HD-Logo1");

            fader = new Color(255, 255, 255, 0);

            base.LoadContent();
        }
        
        public override void Update(GameTime gameTime)
        {
            if(InputHandler.KeyReleased(Keys.Space) || fader.A >= 254)
                StateManager.PushState(GameRef.NextScreen);

            fader.A += 2;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            GameRef.spriteBatch.Begin();

            GameRef.spriteBatch.Draw(promoImage, GameRef.ScreenRectangle, fader);

            GameRef.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
