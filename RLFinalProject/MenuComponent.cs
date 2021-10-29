using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RLFinalProject
{
    public class MenuComponent : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont regularFont, hilightFont, titleFont;
        private List<string> menuItems;
        private int selectedIndex = 0;

        private Vector2 position;
        private Color regularColor = Color.Black;
        private Color hilightColor = Color.Red;

        private KeyboardState oldState;
        private MouseState oldMouse;

        public MenuComponent(Game game, SpriteBatch spriteBatch, SpriteFont regularFont, SpriteFont hilightFont,SpriteFont titleFont,string[] menus) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.regularFont = regularFont;
            this.hilightFont = hilightFont;
            this.titleFont = titleFont;

            menuItems = menus.ToList<string>();

            position = new Vector2(Shared.stage.X / 2-80, Shared.stage.Y / 2-40);
        }

        public int SelectedIndex { get => selectedIndex; set => selectedIndex = value; }

        public override void Draw(GameTime gameTime)
        {
            Vector2 temp = position;
            spriteBatch.Begin();
            
            Vector2 pos = new Vector2(Shared.stage.X / 2-180, 100);
            spriteBatch.DrawString(titleFont, "I Wanna Be The Guy", pos, Color.DarkGreen);

            for (int i = 0; i < menuItems.Count; i++)
            {

                if (selectedIndex == i)
                {
                    spriteBatch.DrawString(hilightFont, menuItems[i], temp, hilightColor);
                    temp.Y += hilightFont.LineSpacing;
                }
                else
                {
                    spriteBatch.DrawString(regularFont, menuItems[i], temp, regularColor);
                    temp.Y += regularFont.LineSpacing;
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            MouseState ms = Mouse.GetState();
            if(ms.LeftButton == ButtonState.Pressed && oldMouse.LeftButton == ButtonState.Released)
            {

            }

            if (ks.IsKeyDown(Keys.Down) && oldState.IsKeyUp(Keys.Down))
            {
                selectedIndex++;
                if (selectedIndex == menuItems.Count)
                {
                    selectedIndex = 0;
                }
            }
            if (ks.IsKeyDown(Keys.Up) && oldState.IsKeyUp(Keys.Up))
            {
                selectedIndex--;
                if (selectedIndex == -1)
                {
                    selectedIndex = menuItems.Count - 1;
                }

            }
            oldState = ks;
            oldMouse = ms;
            base.Update(gameTime);
        }
    }
}
