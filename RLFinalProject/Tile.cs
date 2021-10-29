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
    public class Tile : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        public Vector2 position;
        public string type;

        public Tile(Game game, SpriteBatch spriteBatch, Texture2D tex, Vector2 position, string type) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.type = type;
            this.position = position;
        }
        public void hide()
        {
            this.Visible = false;
        }
        public void show()
        {
            this.Visible = true;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, Color.White);        
            spriteBatch.End();
            base.Draw(gameTime);
        }
        public Rectangle getBound()
        {          
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }
        
    }
}
