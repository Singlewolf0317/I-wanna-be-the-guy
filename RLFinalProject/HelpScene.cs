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
    public class HelpScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        public HelpScene(Game game, SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
            tex = game.Content.Load<Texture2D>("Images/help");
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, new Vector2(Shared.stage.X / 2 - tex.Width / 2, Shared.stage.Y / 2 - tex.Height / 2), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
