using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace hd_005_statetest01.GUI
{
    public class Label : Control
    {
        public Label()
        {
            tabStop = false;
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(SpriteFont, text, Position, Color);
            spriteBatch.End();
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {

        }
    }
}
