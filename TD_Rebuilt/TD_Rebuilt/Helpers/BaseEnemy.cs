using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD_Rebuilt.Helpers;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace TD_Rebuilt.GameObjects
{
    public abstract class BaseEnemy : IEnemy
    {
        protected Texture2D Texture;
        protected Vector2 Position;
        protected int SpriteSheetCount, FrameCount, frameIndex;        
        protected double timeElapsed;
        protected double timeToUpdate;
        protected List<Animation> AnimationList;
        protected bool Idle;
        protected Animation.MovementDirection CurrentDirection;
        private Rectangle HitBox;
        public Rectangle HurtBox { get { return HitBox; } }

        protected BaseEnemy(Vector2 position)
        {            
            Position = position;
            HitBox = new Rectangle(Position.X, Position.Y, Texture.Width, Texture.Height);
            //CurrentDirection = Animation.MovementDirection.East;
        }

        protected void ChangeDirection(Animation.MovementDirection newDirection)
        {
            CurrentDirection = newDirection;
        }

        public void Update(ref GameTime gameTime)
        {
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeElapsed > timeToUpdate)
            {
                timeElapsed -= timeToUpdate;
                if ((frameIndex < AnimationList[(int)CurrentDirection].Length - 1) && !Idle)
                {
                    frameIndex++;
                }
                else
                {
                    frameIndex = 0;
                }
            }
        }

        protected abstract void DrawFrame();

        public void Draw(ref SpriteBatch spriteBatch)
        {
            DrawFrame();
            spriteBatch.Draw(Texture, Position, AnimationList[(int)CurrentDirection].GetArray[frameIndex], Color.White);            
        }

        protected void CreateAnimationList()
        {
            AnimationList = new List<Animation>();
            for (int i = 0; i < SpriteSheetCount; i++)
            {
                var animationArr = Animation.CreateAnimation(ref Texture, FrameCount, i, SpriteSheetCount);
                var animation = new Animation(ref animationArr, (Animation.MovementDirection) i);
                AnimationList.Add(animation);
            }
        }


    }
}
