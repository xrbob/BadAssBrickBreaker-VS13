using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace hd_005_statetest01.Actors
{
    public class BrickManager : List<Brick>
    {
        
        Texture2D image;
        Brick makeBrick;

        public BrickManager(Texture2D image)
        {
            this.image = image;
            
            for(int i = 0; i < 5; i++) 
            {
                makeBrick = new Brick(image, new Rectangle(8, 8 + (i * 20), 32, 16), new Vector2(150 + (i * 32), 150), 1);
                this.Add(makeBrick);
            }
        }

        public void Update(GameTime gameTime)
        {

            foreach (Brick b in this)
            {
                if (b.hitPoints <= 0)
                {
                    this.Remove(b);
                    break;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // for each brick in bricks, 
            // if hitpoint > 0
            // draw

            foreach (Brick b in this)
            {
                if(b.hitPoints > 0)
                    b.Draw(spriteBatch);
            }


        }
    }
}
