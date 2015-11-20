using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace hd_005_statetest01.Actors
{
    public class Ball
    {
        Texture2D image;

        public int width = 16;
        public int height = 16;

        public Vector2 position;
        public Vector2 motion;

        public Rectangle ballRect;

        Rectangle sourceRect;
        Rectangle destRect;

        public bool launched = false;
        
        public Ball(Texture2D image, Vector2 position)
        {
            this.image = image;
            this.position = position;
            motion = new Vector2(0, 0);
            ballRect = new Rectangle((int)position.X, (int)position.Y, width, height);
        }

        public void Update(GameTime gameTime)
        {
            
            if (launched)
            {
                position += motion;
            }

            ballRect = new Rectangle((int)position.X, (int)position.Y, width, height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            sourceRect = new Rectangle(0, 0, 256, 256);
            destRect = new Rectangle((int)position.X, (int)position.Y, width, height);

            spriteBatch.Begin();

            spriteBatch.Draw(image, destRect, sourceRect, Color.White);

            spriteBatch.End();
        }
    }
}
