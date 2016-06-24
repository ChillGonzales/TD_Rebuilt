using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TD_Rebuilt.GameObjects
{
    public class Animation
    {
        //protected Texture2D texture;
        //private Rectangle[] frameBoxArray;               


        //public Animation(Vector2 _position, Texture2D _texture)
        //{
        //    position = _position;
        //    texture = _texture;
        //}
        private Rectangle[] AnimationArray;
        private MovementDirection Name;
        public int Length { get { return AnimationArray.Length; } }
        public Rectangle[] GetArray { get { return AnimationArray; } }
        public enum MovementDirection { East = 0, North = 1, Northeast = 2, Northwest = 3, South = 4, Southeast = 5, Southwest = 6, West = 7 };

        public Animation(ref Rectangle[] animationArray, MovementDirection name)
        {
            AnimationArray = animationArray;
            Name = name;
        }        

        public static Rectangle[] CreateAnimation(ref Texture2D texture, int frameCount, int animationIndex, int spriteSheetRows)
        {
            int frameWidth = texture.Width / frameCount;            
            Rectangle[] frameBoxArray = new Rectangle[frameCount];
            for (int i = 0; i < frameCount; i++)
            {
                frameBoxArray[i] = new Rectangle(i * frameWidth, (texture.Height / spriteSheetRows) * animationIndex, frameWidth, texture.Height / (spriteSheetRows - 1));
            }
            return frameBoxArray;
        }        

    }
}
