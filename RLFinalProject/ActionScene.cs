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
    class ActionScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Kid kid;
        private Tile ground, door, hide;
        private CollisionManager cm;
        private Texture2D tex1, tex2, tex3;
        private List<Tile> tileList = new List<Tile>();
        private Death death;
        private Firework firework;
        private Bullet bullet;
        private MouseState oldState;
        private SoundEffect shootSound ,winSound;


        public ActionScene(Game game, SpriteBatch spriteBatch) : base(game)
        {
            tex1 = game.Content.Load<Texture2D>("Images/killer");
            tex2 = game.Content.Load<Texture2D>("Images/ground");
            tex3 = game.Content.Load<Texture2D>("Images/door");

            this.spriteBatch = spriteBatch;
            kid = new Kid(game, spriteBatch, game.Content.Load<Texture2D>("Images/kid"));
            this.Components.Add(kid);

            bullet = new Bullet(game, spriteBatch, kid.position,game.Content.Load<Texture2D>("Images/bullet"));
            this.Components.Add(bullet);
            
            ground = new Tile(game, spriteBatch,tex1,new Vector2(100,Shared.stage.Y - tex1.Height), "killer");
            tileList.Add(ground);
            this.Components.Add(ground);
            
            ground = new Tile(game, spriteBatch, tex2, new Vector2(200, Shared.stage.Y - 100), "ground");
            tileList.Add(ground);
            this.Components.Add(ground);

            ground = new Tile(game, spriteBatch, tex2, new Vector2(200+ tex2.Width, Shared.stage.Y - 100), "ground");
            tileList.Add(ground);
            this.Components.Add(ground);

            ground = new Tile(game, spriteBatch, tex1, new Vector2(200 + tex2.Width, Shared.stage.Y - 100-tex1.Height), "killer");
            tileList.Add(ground);
            this.Components.Add(ground);

            ground = new Tile(game, spriteBatch, tex2, new Vector2(200 + 2*tex2.Width, Shared.stage.Y - 100), "ground");
            tileList.Add(ground);
            this.Components.Add(ground);

            ground = new Tile(game, spriteBatch, tex2, new Vector2(200 + 3*tex2.Width, Shared.stage.Y - 100), "ground");
            tileList.Add(ground);
            this.Components.Add(ground);

            ground = new Tile(game, spriteBatch, tex1, new Vector2(200 + 4 * tex2.Width, Shared.stage.Y - tex1.Height), "killer");
            tileList.Add(ground);
            this.Components.Add(ground);

            ground = new Tile(game, spriteBatch, tex1, new Vector2(200 + 5 * tex2.Width, Shared.stage.Y - tex1.Height), "killer");
            tileList.Add(ground);
            this.Components.Add(ground);

            ground = new Tile(game, spriteBatch, tex2, new Vector2(200 + 6 * tex2.Width, Shared.stage.Y - 100), "ground");
            tileList.Add(ground);
            this.Components.Add(ground);

            ground = new Tile(game, spriteBatch, tex2, new Vector2(200 + 7 * tex2.Width, Shared.stage.Y - 100), "ground");
            tileList.Add(ground);
            this.Components.Add(ground);

            hide = new Tile(game, spriteBatch, tex1, new Vector2(200 + 11 * tex2.Width, Shared.stage.Y - tex1.Height), "killer");
            tileList.Add(hide);       
            this.Components.Add(hide);
            hide.Visible = false;

            door = new Tile(game, spriteBatch, tex3, new Vector2(Shared.stage.X - tex3.Width,Shared.stage.Y - tex3.Height),"door");
            tileList.Add(door);
            this.Components.Add(door);

            Texture2D tex = game.Content.Load<Texture2D>("Images/death");
            death = new Death(game, spriteBatch, tex, Vector2.Zero, 3);
            this.Components.Add(death);


            foreach (Tile tile in tileList)
            {
                cm = new CollisionManager(game,spriteBatch, kid, tile, death);
                this.Components.Add(cm);
            }

            Texture2D fire = game.Content.Load<Texture2D>("Images/firework");
            firework = new Firework(game, spriteBatch, fire, Vector2.Zero, 3);
            this.Components.Add(firework);

            shootSound = game.Content.Load<SoundEffect>("Sounds/shoot");
            winSound = game.Content.Load<SoundEffect>("Sounds/win");
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            Vector2 pos = new Vector2(0, 0);
            if (cm.isWin)
            {
                firework.Position = new Vector2(pos.X + 200, pos.Y);
                firework.start();
                cm.isWin = false;
                winSound.Play();
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();
            if(kid.position.X == 200+9 * tex2.Width)
            {
                hide.Visible = true;
            }
            if (ms.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                bullet.start();
                shootSound.Play();
                bullet.position = new Vector2(kid.position.X + kid.tex.Width, kid.position.Y + kid.tex.Height / 2);
            }
            oldState = ms;
            base.Update(gameTime);
        }
    }
}
