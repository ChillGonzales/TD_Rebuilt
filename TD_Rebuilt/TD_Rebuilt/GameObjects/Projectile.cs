using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TD_Rebuilt.Helpers;

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
        public CircleTrigger HitBox;

        public Projectile(Vector2 pos)
        {
            Position = pos;
            Texture = GameLoop.fireProjectileTexture;
            timeToUpdate = 1 / 10f;
            CreateAnimationList();
            HitBox = new CircleTrigger(Position, Texture.Width / 2);
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
            spriteBatch.Draw(Texture, FireAnimationList[(int)CurrentDirection].GetArray[FrameIndex],Color.White);           
        }

        protected void DrawFrame()
        {
            Position += Animation.Move(CurrentDirection);
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
