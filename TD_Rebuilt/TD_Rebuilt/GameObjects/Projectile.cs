using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TD_Rebuilt.GameObjects
{
    public class Projectile
    {
        private Vector2 Position;
        private Texture2D Texture;
        private int FrameCount = 6, FrameIndex = 0;
        private List<Animation> FireAnimationList;
        private double timeElapsed, timeToUpdate;
        private Animation.MovementDirection CurrentDirection;

        public Projectile(Vector2 pos)
        {
            Position = pos;
            Texture = GameLoop.fireProjectileTexture;
            CreateAnimationList();
        }        

        public void Update(ref GameTime gameTime)
        {
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeElapsed > timeToUpdate)
            {
                timeElapsed -= timeToUpdate;
                if ((FrameIndex < FireAnimationList[(int)CurrentDirection].Length - 1))
                {
                    FrameIndex++;
                }
                else
                {
                    FrameIndex = 0;
                }
            }
        }

        public void Draw(ref SpriteBatch spriteBatch)
        {
            DrawFrame();
            spriteBatch.Draw()            
        }

        protected void DrawFrame()
        {
            switch (CurrentDirection)
            {
                case Animation.MovementDirection.East:
                    Position.X += 1;
                    break;
                case Animation.MovementDirection.North:
                    Position.Y -= 1;
                    break;
                case Animation.MovementDirection.West:
                    Position.X -= 1;
                    break;
                case Animation.MovementDirection.South:
                    Position.Y += 1;
                    break;
                case Animation.MovementDirection.Southwest:
                    Position.X -= 0.5f;
                    Position.Y += 0.5f;
                    break;
                case Animation.MovementDirection.Southeast:
                    Position.X += 0.5f;
                    Position.Y += 0.5f;
                    break;
                case Animation.MovementDirection.Northwest:
                    Position.X -= 0.5f;
                    Position.Y -= 0.5f;
                    break;
                case Animation.MovementDirection.Northeast:
                    Position.X += 0.5f;
                    Position.Y -= 0.5f;
                    break;
            }
        }

        protected void CreateAnimationList()
        {
            FireAnimationList = new List<Animation>();
            for (int i = 0; i < 8; i++)
            {
                var animationArr = Animation.CreateAnimation(ref Texture, FrameCount, i, 8);
                var animation = new Animation(ref animationArr, (Animation.MovementDirection)i);
                FireAnimationList.Add(animation);
            }
        }



    }
}
