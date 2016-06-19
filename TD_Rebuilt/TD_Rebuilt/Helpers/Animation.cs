using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TD_Rebuilt.GameObjects
{
    public abstract class Animation
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected bool idle;
        private Rectangle[] frameBoxArray;
        private int frameIndex;
        private double timeElapsed, timeToUpdate;        


        public Animation(Vector2 _position, Texture2D _texture)
        {
            position = _position;
            texture = _texture;
        }

        public void CreateAnimation(int frameCount, int rowNumber, int animationIndex)
        {
            int frameWidth = texture.Width / frameCount;
            timeToUpdate = 1f / frameCount;
            frameBoxArray = new Rectangle[frameCount];
            for (int i = 0; i < frameCount; i++)
            {
                frameBoxArray[i] = new Rectangle(i * frameWidth, (texture.Height / animCount), animationIndex, frameWidth, texture.Height / animCount);
            }
        }

    }
}
