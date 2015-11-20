using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace hd_005_statetest01.GUI
{
    public class Walls
    {
        Texture2D image;

        public int width = 16;

        Rectangle sourceRect;
        Rectangle destRect;

        Game1 game;

        public Walls(Texture2D image, Game1 game)
        {
            this.image = image;
            this.game = game;
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch, int colour)
        {
            sourceRect = new Rectangle((width * colour), 0, width, 96);

            spriteBatch.Begin();

            // Draw Left Wall
            for (int i = 0; i <= 7; i++)
            {
                destRect = new Rectangle(0, (i * 96), width, 96);
                spriteBatch.Draw(image, destRect, sourceRect, Color.White);
            }
            // Draw Right Wall
            for (int i = 0; i <= 7; i++)
            {
                destRect = new Rectangle((game.ScreenRectangle.Width - width), (i * 96), width, 96);
                spriteBatch.Draw(image, destRect, sourceRect, Color.White, 0.0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1.0f);
            }

            // Draw Roof
            for (int i = 0; i <= 9; i++)
            {
                destRect = new Rectangle((i * 96) + width, 0, width, 96);
                spriteBatch.Draw(image, destRect, sourceRect, Color.White, 1.5707f, new Vector2(0, 96), SpriteEffects.None, 1.0f);
            }

           

            spriteBatch.End();
        }

        
    }
}
