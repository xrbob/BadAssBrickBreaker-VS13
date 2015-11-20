using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using hd_005_statetest01.GUI;

namespace hd_005_statetest01.Actors
{
    public class PaddleManager : List<Paddle>
    {
        Texture2D image;
        Paddle makePaddle;

        public int activePaddle = 0;
        int paddleSpeed = 5;

        public PaddleManager(Texture2D image, Game1 gameRef)
        {
            this.image = image;

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Rectangle srcRect = new Rectangle(48 + (x * 68), 72 + (y * 20), 64, 16);
                    makePaddle = new Paddle(image, srcRect, 0, new Vector2((gameRef.ScreenRectangle.Width / 2) - 32, gameRef.ScreenRectangle.Height - 50));
                    makePaddle.type = 0;
                    this.Add(makePaddle);
                }
            }

            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    Rectangle srcRect = new Rectangle(8 + (x * 68), 151 + (y * 24), 64, 20);
                    makePaddle = new Paddle(image, srcRect, 0, new Vector2((gameRef.ScreenRectangle.Width / 2) - 32, gameRef.ScreenRectangle.Height - 50));
                    makePaddle.type = 1;
                    this.Add(makePaddle);
                }
            }

        }

        public void Update(GameTime gameTime, Game1 gameRef, Walls walls)
        {

            if (InputHandler.KeyDown(Keys.Right))
            {
                this[activePaddle].position.X += paddleSpeed;
                if (this[activePaddle].position.X > (gameRef.ScreenRectangle.Width - walls.width - this[activePaddle].paddleRect.Width))
                    this[activePaddle].position.X = (gameRef.ScreenRectangle.Width - walls.width - this[activePaddle].paddleRect.Width);
            }
            // move paddle
            if (InputHandler.KeyDown(Keys.Left))
            {
                this[activePaddle].position.X -= paddleSpeed;
                if (this[activePaddle].position.X < walls.width)
                    this[activePaddle].position.X = walls.width;
            }

            if (InputHandler.KeyReleased(Keys.A) && activePaddle <= 15)
            {
                activePaddle++;
                this[activePaddle].paddleRect.X = (gameRef.ScreenRectangle.Width / 2) - 32;
            }

            if (InputHandler.KeyReleased(Keys.Q) && activePaddle >= 1)
            {
                activePaddle--;
                this[activePaddle].paddleRect.X = (gameRef.ScreenRectangle.Width / 2) - 32;
            }

            this[activePaddle].Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this[activePaddle].Draw(spriteBatch);
        }
    }
}
