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
    public class Kid : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        public Texture2D tex;
        public Vector2 position;
        public Vector2 run, jump, speed, gravity;
        private KeyboardState oldState;
        public bool isJump;

        public Kid(Game game, SpriteBatch spriteBatch, Texture2D tex) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            position = new Vector2(0, Shared.stage.Y - tex.Height);

            run = new Vector2(2, 0);
            gravity = new Vector2(0, 0.3f);
            jump = new Vector2(0, 0);
            speed = new Vector2(0, 0);
        }
        public Vector2 Run { get => run; set => run = value; }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();

            jump.Y += gravity.Y;
            position.Y += jump.Y;
            if (position.Y >= Shared.stage.Y - tex.Height)
            {
                jump.Y = 0;
                position.Y = Shared.stage.Y - tex.Height;
                isJump = false;
            }

            if (ks.IsKeyDown(Keys.D))
            {
                speed.X = run.X;
                position.X += speed.X;
                if (position.X > Shared.stage.X - tex.Width)
                {
                    position.X = Shared.stage.X - tex.Width;
                }
            }
            if (ks.IsKeyDown(Keys.A))
            {
                speed.X = run.X;
                position.X -= speed.X;
                if (position.X < 0)
                {
                    position.X = 0;
                }
            }

            if (!isJump && ks.IsKeyDown(Keys.Space) && oldState.IsKeyUp(Keys.Space))
            {
                gravity.Y = 0.4f;
                jump.Y = -10;
                speed.Y = jump.Y;
                position.Y += speed.Y;
                
                isJump = true;

                if (position.Y < 0)
                {
                    position.Y = 0;
                }
            }

            oldState = ks;
            base.Update(gameTime);
        }
        public Rectangle getBound()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);

        }
    }
}
