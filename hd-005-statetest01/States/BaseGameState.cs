using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using hd_005_statetest01;
using hd_005_statetest01.GUI;

namespace hd_005_statetest01.States
{
    public abstract partial class BaseGameState : GameState
    {
        protected Game1 GameRef;
        protected PlayerIndex playerIndexInControl;
        protected ControlManager controlManager;

        public BaseGameState(Game game, GameStateManager manager)
            : base(game, manager)
        {
            GameRef = (Game1)game;
            playerIndexInControl = PlayerIndex.One;
        }

        protected override void LoadContent()
        {
            ContentManager content = Game.Content;

            SpriteFont mainFont = content.Load<SpriteFont>(@"MainFont");
            controlManager = new ControlManager(mainFont);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

    }
}
