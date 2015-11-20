using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace hd_005_statetest01.Actors
{
    public class Paddle
    {
        Texture2D image;

        int width = 64;
        int height = 16;
        public int type = 0;

        public Vector2 position;

        public Rectangle paddleRect;
        Rectangle sourceRect;
        
        public Paddle(Texture2D image, Rectangle sourceRect, int type, Vector2 position)
        {
            this.image = image;
            this.position = position;
            this.type = type;
            this.sourceRect = sourceRect;
            paddleRect = new Rectangle((int)position.X, (int)position.Y, width, height);
        }

        public void Update(GameTime gameTime)
        {
            paddleRect = new Rectangle((int)position.X, (int)position.Y, width, height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Begin();

            spriteBatch.Draw(image, paddleRect, sourceRect, Color.White);

            spriteBatch.End();
        }
    }
}
