using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RLFinalProject
{
    public class CollisionManager : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Kid kid;
        private Tile tile;
        private Death death;
        private static int count;
        private SpriteFont regular;
        public bool isWin;
        

        public CollisionManager(Game game,SpriteBatch spriteBatch, Kid kid,Tile tile, Death death) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.kid = kid;
            this.tile = tile;
            this.death = death;          
            regular = game.Content.Load<SpriteFont>("Fonts/regular");         
        }

        public override void Update(GameTime gameTime)
        {
            Rectangle kidRect = kid.getBound();
            Rectangle tileRect = tile.getBound();
            Rectangle intercept = Rectangle.Intersect(kidRect,tileRect);
            if (!kidRect.Intersects(tileRect))
            {
                kid.gravity.Y = 0.4f;
            }
            if (tile.type == "ground")
            {
                if(kidRect.Intersects(tileRect) && intercept.Width<intercept.Height && intercept.X == tileRect.X)
                {
                    kid.position.X = tile.position.X - kidRect.Width;
                }

                if (kidRect.Intersects(tileRect) && intercept.Width < intercept.Height && intercept.X == kidRect.X)
                {
                    kid.position.X = tile.position.X + tileRect.Width;
                }
                if (kidRect.Intersects(tileRect) && intercept.Width >= intercept.Height && intercept.Y == tileRect.Y)
                {
                    kid.isJump = false;
                    kid.jump.Y = 0;
                    kid.speed.Y = 0;
                    kid.gravity.Y = 0;
                    kid.position.Y = tile.position.Y - tileRect.Height;
                }
                if (kidRect.Intersects(tileRect) && intercept.Width > intercept.Height && intercept.Y == kidRect.Y)
                {
                    kid.position.Y = tile.position.Y + tileRect.Height;
                }

            }
            else if(tile.type == "killer")
            {
                if (kidRect.Intersects(tileRect))
                {                    
                    death.Position = new Vector2(kid.position.X, kid.position.Y);
                    death.start();
                    kid.position = new Vector2(0, Shared.stage.Y - kid.tex.Height);
                    count++;
                }                
            }
            else
            {
                if (kidRect.Intersects(tileRect) && tile.type == "door")
                {
                    count = 0;
                    isWin = true;
                    kid.position = new Vector2(0, Shared.stage.Y - kid.tex.Height);
                }
            }
            
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            Vector2 pos = new Vector2(0, 0);
            if(count != 0)
            {
                spriteBatch.DrawString(regular, "Total Deaths: " + count, pos, Color.Black);
            }
            else
            {
                spriteBatch.DrawString(regular, "Total Deaths: ", pos, Color.Black);
            }
            
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
