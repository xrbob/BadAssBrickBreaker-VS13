using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using hd_005_statetest01.GUI;
using hd_005_statetest01.Actors;

namespace hd_005_statetest01.States
{
    public class GameScreen : BaseGameState
    {
        Walls walls;
        int wallColour = 0;

        Ball mainBall;
        int ballSpeed = 3;

        BrickManager brickManager;

        PaddleManager paddleManager;

        Game1 game;

        int score = 0;

        Label scoreLabel;

        public GameScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {
            this.game = (Game1)game;  
        }

        protected override void LoadContent()
        {

            base.LoadContent();

            ContentManager content = GameRef.Content;

            walls = new Walls(content.Load<Texture2D>("breakout"), game);

            paddleManager = new PaddleManager(content.Load<Texture2D>("breakout_pieces_1"), GameRef);

            mainBall = new Ball(content.Load<Texture2D>("sphere-00"), new Vector2((GameRef.ScreenRectangle.Width / 2) - 16, (paddleManager[paddleManager.activePaddle].position.Y - 16)));

            brickManager = new BrickManager(content.Load<Texture2D>("breakout_pieces_1"));

            scoreLabel = new Label();
            scoreLabel.Name = "Score";
            scoreLabel.Position = new Vector2(GameRef.ScreenRectangle.Width - 100, GameRef.ScreenRectangle.Height - 25);
            scoreLabel.Text = score.ToString();
            controlManager.Add(scoreLabel);

            
        }

        void CheckCollision()
        {
            // left wall
            if (mainBall.position.X < walls.width)
                mainBall.motion = new Vector2(-mainBall.motion.X, mainBall.motion.Y);

            // right wall
            if ((mainBall.position.X + mainBall.width) > (GameRef.ScreenRectangle.Width - walls.width))
                mainBall.motion = new Vector2(-mainBall.motion.X, mainBall.motion.Y);

            // top wall
            if (mainBall.position.Y < walls.width)
                mainBall.motion = new Vector2(mainBall.motion.X, -mainBall.motion.Y);
            
            // bricks
            foreach (Brick b in brickManager)
            {
                if (b.destRect.Intersects(mainBall.ballRect))
                {
                    b.hitPoints--;
                    score++;
                    if (b.hitPoints <= 0)
                        score += 10;
                    Vector2 reboundDirection = new Vector2(0, 0);
                    reboundDirection = (mainBall.position + new Vector2(mainBall.ballRect.Width / 2, mainBall.ballRect.Height / 2)) - (b.position + new Vector2(b.destRect.Width / 2, b.destRect.Height / 2));
                    reboundDirection.Normalize();
                    mainBall.motion = reboundDirection * ballSpeed;
                }
            }

            // paddle
         
            if(paddleManager[paddleManager.activePaddle].paddleRect.Intersects(mainBall.ballRect)) 
            {
                Vector2 reboundDirection = new Vector2(0, 0);
                reboundDirection = (mainBall.position + new Vector2(mainBall.ballRect.Width / 2, mainBall.ballRect.Height / 2)) - (paddleManager[paddleManager.activePaddle].position + new Vector2(paddleManager[paddleManager.activePaddle].paddleRect.Width / 2, paddleManager[paddleManager.activePaddle].paddleRect.Height / 2));
                reboundDirection.Normalize();
                mainBall.motion = reboundDirection * ballSpeed;

            }
            
           
            

        }

        public override void Update(GameTime gameTime)
        {

            CheckCollision();

            if(mainBall.launched == false)
                mainBall.position.X = paddleManager[paddleManager.activePaddle].position.X + 16;

            if (InputHandler.KeyDown(Keys.Space))
            {
                if (mainBall.launched == false)
                {
                    mainBall.motion = new Vector2(ballSpeed, -ballSpeed);
                    mainBall.launched = true;
                }

            }

            paddleManager.Update(gameTime, GameRef, walls);
            mainBall.Update(gameTime);
            brickManager.Update(gameTime);

            scoreLabel.Text = score.ToString();

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Blue);

            walls.Draw(GameRef.spriteBatch, wallColour);
            controlManager.Draw(GameRef.spriteBatch);
            paddleManager.Draw(GameRef.spriteBatch);
            mainBall.Draw(GameRef.spriteBatch);
            brickManager.Draw(GameRef.spriteBatch);

            base.Draw(gameTime);
        }
    }
}
