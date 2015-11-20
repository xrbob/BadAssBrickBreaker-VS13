using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace hd_005_statetest01.GUI
{
    public class ControlManager : List<Control>
    {
        int selectedControl = 0;

        static SpriteFont spriteFont;

        public event EventHandler FocusChanged;

        public static SpriteFont SpriteFont
        {
            get { return spriteFont; }
        }

        public ControlManager(SpriteFont spriteFont)
            : base()
        {
            ControlManager.spriteFont = spriteFont;
        }

        public ControlManager(SpriteFont spriteFont, int capacity)
            : base(capacity)
        {
            ControlManager.spriteFont = spriteFont;
        }

        public ControlManager(SpriteFont spriteFont, IEnumerable<Control> collection)
            : base(collection)
        {
            ControlManager.spriteFont = spriteFont;
        }

        public void Update(GameTime gametime, PlayerIndex playerIndex)
        {
            if (Count == 0)
                return;

            foreach (Control c in this)
            {
                if (c.Enabled)
                    c.Update(gametime);
                if (c.HasFocus)
                    c.HandleInput(playerIndex);
            }

            if (InputHandler.KeyPressed(Keys.Up))
            {
                PreviousControl();
            }

            if (InputHandler.KeyPressed(Keys.Down))
            {
                NextControl();
            }
        }

        public void Draw(SpriteBatch SpriteBatch)
        {
            foreach (Control c in this)
            {
                if (c.Visible)
                    c.Draw(SpriteBatch);
            }

        }

        public void NextControl()
        {
            if (Count == 0)
                return;

            int currentControl = selectedControl;

            this[selectedControl].HasFocus = false;

            do
            {
                selectedControl++;
                if (selectedControl == Count)
                    selectedControl = 0;
                if (this[selectedControl].TabStop && this[selectedControl].Enabled)
                {
                    if (FocusChanged != null)
                    {
                        FocusChanged(this[selectedControl], null);
                    }
                    break;
                }

            } while (currentControl != selectedControl);

            this[selectedControl].HasFocus = true;
        }

        public void PreviousControl()
        {
            if (Count == 0)
                return;

            int currentControl = selectedControl;

            this[selectedControl].HasFocus = false;

            do
            {
                selectedControl--;

                if (selectedControl < 0)
                    selectedControl = Count - 1;

                if (this[selectedControl].TabStop && this[selectedControl].Enabled)
                {
                    if (FocusChanged != null)
                    {
                        FocusChanged(this[selectedControl], null);
                    }
                    break;
                }
            } while (currentControl != selectedControl);

            this[selectedControl].HasFocus = true;
        }
    }
}
