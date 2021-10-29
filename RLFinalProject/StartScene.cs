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
    public class StartScene : GameScene
    {
        private MenuComponent menu;
        private SpriteBatch spriteBatch;
        private string[] menuItems = { "Start game", "Help", "About", "Quit" };
        private Firework firework;
        private MouseState oldState;

        public MenuComponent Menu { get => menu; set => menu = value; }

        public StartScene(Game game, SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
            menu = new MenuComponent(game, spriteBatch,
                game.Content.Load<SpriteFont>("Fonts/regular"),
                game.Content.Load<SpriteFont>("Fonts/highlight"),
                game.Content.Load<SpriteFont>("Fonts/title"),
                menuItems);
            
            this.Components.Add(menu);

            Texture2D tex = game.Content.Load<Texture2D>("Images/firework");
            firework = new Firework(game, spriteBatch, tex, Vector2.Zero, 3);
            this.Components.Add(firework);
        }

        public override void Update(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();
            if(ms.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                firework.Position = new Vector2(ms.X - 50, ms.Y - 60);
                firework.start();
            }
            oldState = ms;
            base.Update(gameTime);
        }
    }
}
