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
    public class AboutScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private SpriteFont regularFont;
        public AboutScene(Game game, SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
            regularFont = game.Content.Load<SpriteFont>("Fonts/regular");
            //tex = game.Content.Load<Texture2D>("Images/helpImage");
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            Vector2 pos = new Vector2(Shared.stage.X / 2 - 80, 100);
            spriteBatch.DrawString(regularFont, "Ruoyan Li", pos, Color.Firebrick);
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
