using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;


namespace RLFinalProject
{
    public class Bullet : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        public Texture2D tex;
        public Vector2 position;
        private Vector2 speed;
        public Bullet(Game game, SpriteBatch spriteBatch, Vector2 position, Texture2D tex) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            speed = new Vector2(20, 0);           
        }

        public void start()
        {
            this.Enabled = true;
            this.Visible = true;
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, Color.White);          
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            position += speed;
            base.Update(gameTime);
        }
    }
}
