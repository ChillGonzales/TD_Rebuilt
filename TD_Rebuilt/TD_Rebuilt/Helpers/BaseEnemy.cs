﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD_Rebuilt.Helpers;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TD_Rebuilt.GameObjects
{
    public abstract class BaseEnemy
    {
        protected Texture2D Texture;
        protected Vector2 Position;
        protected int SpriteSheetCount, FrameCount, frameIndex;        
        protected double timeElapsed;
        protected double timeToUpdate;
        protected List<Animation> AnimationList;
        protected Animation.MovementDirection CurrentDirection;        

        protected BaseEnemy(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
            CurrentDirection = Animation.MovementDirection.Idle;
        }

        protected void ChangeDirection(Animation.MovementDirection newDirection)
        {
            CurrentDirection = newDirection;
        }

        private void Update(GameTime gameTime)
        {
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeElapsed > timeToUpdate)
            {
                timeElapsed -= timeToUpdate;
                if ((frameIndex < AnimationList[(int)CurrentDirection].Length - 1) && ((int)CurrentDirection != 8))
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

        protected void Draw(SpriteBatch spriteBatch)
        {

        }

        protected void CreateAnimationList()
        {
            AnimationList = new List<Animation>();
            for (int i = 0; i > SpriteSheetCount; i++)
            {
                var animationArr = Animation.CreateAnimation(ref Texture, FrameCount, i, SpriteSheetCount);
                var animation = new Animation(ref animationArr, (Animation.MovementDirection) i);
                AnimationList.Add(animation);
            }
        }


    }
}