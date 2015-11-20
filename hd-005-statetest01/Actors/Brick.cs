using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace hd_005_statetest01.Actors
{
    public class Brick
    {
        public Vector2 position;
        public int width;
        public int height;
        public int hitPoints;

        Texture2D image;

        Rectangle sourceRect;
        public Rectangle destRect;

        public Brick(Texture2D image, Rectangle sourceRect, Vector2 position, int hitPoints)
        {
            this.image = image;
            this.sourceRect = sourceRect;
            this.position = position;
            this.hitPoints = hitPoints;

            width = sourceRect.Width;
            height = sourceRect.Height;

            destRect = new Rectangle((int)position.X, (int)position.Y, width, height);

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(image, destRect, sourceRect, Color.White);
            
            spriteBatch.End();
        }

    }
}
